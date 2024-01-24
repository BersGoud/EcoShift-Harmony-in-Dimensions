using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JV_LevellSetup : MonoBehaviour
{
    public Ending endingCanvas;
    private DimensionalShift shift;
    // Start is called before the first frame update
    void Start()
    {
        shift = gameObject.GetComponent<DimensionalShift>();
        shift.isDimensionalShiftEnabled = true;
        shift.OnCameraChanged += DimensionalShift_OnCameraChanged;
    }
    // Code used to shift between perspectives
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
