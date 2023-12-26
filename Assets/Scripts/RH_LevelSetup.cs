using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update

    public BoxCollider Key;

    void Start()
    {
        DimensionalShift.isDimensionalShiftEnabled = true;
        DimensionalShift.OnCameraChanged += DimensionalShift_OnCameraChanged;
    }

    private void DimensionalShift_OnCameraChanged(bool cameraIs3D)
    {
        GameObject[] remove = GameObject.FindGameObjectsWithTag("RemoveIn2D");
        if (!cameraIs3D)
        {
            foreach (GameObject obj in remove)
            {
                obj.GetComponent<Renderer>().enabled = false;
            }
            Key.enabled = true;
        } else
        {
            foreach (GameObject obj in remove)
            {
                obj.GetComponent<Renderer>().enabled = true;
            }
            Key.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
