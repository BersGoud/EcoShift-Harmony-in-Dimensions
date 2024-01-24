using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DimensionalShift : MonoBehaviour
{
    public Camera camera3D;
    public Camera camera2D;
    public float transitionDuration = 1.0f; // Adjust the duration of the transition
    public Transform player;

    private bool isSwitching = false;
    public float maxOrthoSize = 5.0f; //max size of the 2D cam

    public bool isDimensionalShiftEnabled = false;

    public delegate void CameraChanged(bool cameraIs3D);
    public event CameraChanged OnCameraChanged;

    void Start()
    {
        //initial camera should be 3D
        Enable3DCamera();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (isDimensionalShiftEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2) && !isSwitching && camera3D.enabled)
            {
                StartCoroutine(SwitchTo2DCamera());
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && !isSwitching && camera2D.enabled)
            {
                StartCoroutine(SwitchTo3DCamera());
            }

            if (camera2D.enabled)
            {
                camera2D.transform.position = new Vector3(player.position.x, camera2D.transform.position.y, player.position.z);
            }
        }
    }

    void Enable3DCamera()
    {
        camera3D.enabled = true;
        camera2D.enabled = false;
        if (OnCameraChanged != null)
            OnCameraChanged(camera3D.enabled);
    }

    void Enable2DCamera()
    {
        camera2D.enabled = true;
        camera3D.enabled = false;
        if (OnCameraChanged != null)
            OnCameraChanged(camera3D.enabled);
    }
    
    //Coroutine to swap from 3D to 2D with a transition time
    System.Collections.IEnumerator SwitchTo2DCamera()
    {
        ThirdPersonController controller = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();

        isSwitching = true;

        Debug.Log("Checking player");
        if (player != null)
        {
            Debug.Log("Changing camera pos");
            camera2D.transform.position = new Vector3(player.position.x, camera2D.transform.position.y, player.position.z );
        }

        Enable2DCamera();

        controller.MainCamera = camera2D;
        controller.Invert = true;

        // camera2D.transform.rotation = camera3D.transform.rotation; 

        yield return LerpCamera(camera2D, 0.5f, maxOrthoSize, transitionDuration);

        isSwitching = false;
    }
    
    //Coroutine to swap from 2D to 3D with a transition time
    System.Collections.IEnumerator SwitchTo3DCamera()
    {
        ThirdPersonController controller = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();

        isSwitching = true;

        yield return LerpCamera(camera2D, maxOrthoSize, 0.5f, transitionDuration);

        controller.MainCamera = camera3D;
        controller.Invert = false;

        Enable3DCamera();

        isSwitching = false;
    }

    //coroutine to smoothly adjust camera size
    private System.Collections.IEnumerator LerpCamera(Camera camera, float lerpStart, float lerpStop, float duration)
    {
        float timer = 0.0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;

            camera.orthographicSize = Mathf.Lerp(lerpStart, lerpStop, t);
            yield return null;
        }
    }
}