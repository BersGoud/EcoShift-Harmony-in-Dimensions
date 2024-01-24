using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Setup_MK : MonoBehaviour
{

    protected GameObject player;
    private DimensionalShift shift;
    public CableGamemanager gameManager = CableGamemanager.Instance;

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

    public GameObject GetPlayer()
    {
        return player;
    }
    
}
