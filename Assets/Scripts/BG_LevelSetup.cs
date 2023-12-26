using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Leve : MonoBehaviour
{
    // Start is called before the first frame update
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
                obj.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject obj in remove)
            {
                obj.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
