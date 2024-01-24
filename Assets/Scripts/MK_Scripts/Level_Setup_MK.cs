using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script controls the main mechanics of my level. It also holds the base to the
/// minigame you play to enable the power.
/// </summary>

public class Level_Setup_MK : MonoBehaviour
{

    [Header("objects needed to run")]
    private GameObject player;
    private DimensionalShift shift;
    public CableGamemanager gameManager = CableGamemanager.Instance;

   void Start()
    {
        //This is a piece of code run by ever script. It is a reference to the main mechanic, controls 
        //whether or not the shifting is enabled
        // and adds an extra function to the OnCameraChanged event
        shift = gameObject.GetComponent<DimensionalShift>();
        shift.isDimensionalShiftEnabled = false;
        shift.OnCameraChanged += DimensionalShift_OnCameraChanged;
    }
    
   /// <summary>
   /// This is where the logic is implemented to change the design
   /// of your level based on the cameraState. Objects that need
   /// to be changed can get a tag "RemoveIn2D" or "Shiftable" depending on if
   /// it needs to be relocated or removed.
   /// </summary>
   /// <param name="cameraIs3D"> boolean; state of the camera</param>
   /// <returns></returns>
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
   
    public DimensionalShift getShift()
    {
        return this.shift;
    }

    //some lines of code to reduce repetitiveness of my code. Just changes the Ylevel of the object
	private void ChangeYLevel(GameObject obj, float val)
	{
		Vector3 currentPosition = obj.transform.position;
        currentPosition.y = val;
        obj.transform.position = currentPosition;
	}
}

    
    

