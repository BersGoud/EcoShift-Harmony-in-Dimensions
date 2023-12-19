using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableConnect : MonoBehaviour
{
    public CableEnd objectA;
    private bool ismousedown = false;
    private Vector3 initialposition;
    private bool isMouseOverTarget = false;
    public void OnMouseDown() 
    {
        Debug.Log("Mouse down on: " + gameObject.name);
        ismousedown = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) // Changed to GetMouseButtonUp for mouse up event
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked object is the targetObject in ObjectA
                if (hit.collider.gameObject == objectA.targetObject && ismousedown)
                {
                    // The mouse button is released on the target object
                    Debug.Log("Mouse up on: " + objectA.name);
                    ismousedown = false;
                }
                else
                {
                    ismousedown = false;
                }
            }
        }
    }
}
