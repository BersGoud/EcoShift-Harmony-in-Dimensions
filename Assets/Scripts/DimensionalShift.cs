using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionalShift : MonoBehaviour
{
    public Camera camera3D;
    public Camera camera2D;
    public float transitionDuration = 1.0f; // Adjust the duration of the transition

    private bool isSwitching = false;
    public float maxOrthoSize = 5.0f; //max size of the 2D cam

    private GameObject player = GameObject().FindWithTag("player");
    


    void Start()
    {
        //initial camera should be 3D
        Enable3DCamera();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isSwitching)
        {
            StartCoroutine(SwitchTo2DCamera());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && !isSwitching)
        {
            StartCoroutine(SwitchTo3DCamera());
        }
    }
    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("2DTrigger"))
    //     {
    //         ShiftTo2D();
    //     }
    // }
    //
    // void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("2DTrigger"))
    //     {
    //         ShiftTo3D();
    //     }
    // }

    void Enable3DCamera()
    {
        camera3D.enabled = true;
        camera2D.enabled = false;
    }

    void Enable2DCamera()
    {
        camera2D.enabled = true;
        camera3D.enabled = false;
    }
    
    //Coroutine to swap from 3D to 2D with a transition time
    System.Collections.IEnumerator SwitchTo2DCamera()
    {
        isSwitching = true;
        float timer = 0.0f;
        float initialFOV = camera3D.fieldOfView;

        while (timer < transitionDuration)
        {
            timer += Time.deltaTime;
            float t = timer / transitionDuration;

            camera3D.fieldOfView = Mathf.Lerp(initialFOV, 0f, t);
            yield return null;
        }

        Enable2DCamera();

        timer = 0.0f;
        while (timer < transitionDuration)
        {
            timer += Time.deltaTime;
            float t = timer / transitionDuration;

            // Clamp the orthographic size to the specified maximum
            camera2D.orthographicSize = Mathf.Lerp(0f, initialFOV, t);
            camera2D.orthographicSize = Mathf.Clamp(camera2D.orthographicSize, 0f, maxOrthoSize);
            yield return null;
        }

        isSwitching = false;
    }
    
    //Coroutine to swap from 2D to 3D with a transition time
    System.Collections.IEnumerator SwitchTo3DCamera()
    {
        isSwitching = true;
        float timer = 0.0f;
        float initialOrthoSize = camera2D.orthographicSize;

        while (timer < transitionDuration)
        {
            timer += Time.deltaTime;
            float t = timer / transitionDuration;

            // Clamp the orthographic size to the specified maximum
            camera2D.orthographicSize = Mathf.Lerp(initialOrthoSize, 0f, t);
            camera2D.orthographicSize = Mathf.Clamp(Mathf.Lerp(initialOrthoSize, 0f, t), 0f, maxOrthoSize);
            yield return null;
        }

        Enable3DCamera();

        timer = 0.0f;
        while (timer < transitionDuration)
        {
            timer += Time.deltaTime;
            float t = timer / transitionDuration;

            camera3D.fieldOfView = Mathf.Lerp(0f, 60f, t);
            yield return null;
        }

        isSwitching = false;
    }
}