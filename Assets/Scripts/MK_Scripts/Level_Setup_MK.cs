using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level_Setup_MK : MonoBehaviour
{

    private GameObject player;
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
        GameObject[] remove = GameObject.FindGameObjectsWithTag("RemoveIn2D");
		GameObject[] raise = GameObject.FindGameObjectsWithTag("Shiftable");
        if (!cameraIs3D)
        {
        	foreach (GameObject obj in remove)
            {
                obj.SetActive(false);
            }
			foreach (GameObject obj in raise)
            {
                ChangeYLevel(obj, 4.5f);
            }
          
        } else
        {
            foreach (GameObject obj in remove)
            {
                obj.SetActive(true);
            }
			foreach (GameObject obj in raise)
            {
               ChangeYLevel(obj, 0.1f);
            }	
           
        }
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public DimensionalShift getShift()
    {
        return this.shift;
    }

	private void ChangeYLevel(GameObject obj, float val)
	{
		Vector3 currentPosition = obj.transform.position;
        currentPosition.y = val;
        obj.transform.position = currentPosition;
	}
}

    
    

