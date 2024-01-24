using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Setup_MK : MonoBehaviour
{

    private GameObject _player;
    private DimensionalShift shift;
    CableGamemanager gameManager = CableGamemanager.Instance;

   
    void Start()
    {
        shift = gameObject.GetComponent<DimensionalShift>();
        shift.isDimensionalShiftEnabled = false;
        shift.OnCameraChanged += DimensionalShift_OnCameraChanged;
        // DimensionalShift.isDimensionalShiftEnabled = true;
    }
    
    private void DimensionalShift_OnCameraChanged(bool cameraIs3D)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
