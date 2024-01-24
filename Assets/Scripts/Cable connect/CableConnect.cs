using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableConnect : MonoBehaviour
{
    public CableManager cableManager;
    public CableEnd cableEnd;
    public Transform point1;
    public Transform point2;
    public Transform parent;
    public Material cylinderMaterial;
    public Camera mainCamera;
    private bool ismousedown = false;
    private GameObject cylinder;
    public void OnMouseDown() 
    {
        // Check whether the mouse is held down
        Debug.Log("Mouse down on: " + gameObject.name);
        ismousedown = true;
    }
    // Script for creating the cable(cylinder)
    public void SpawnObject()
    {
        // Get positions of the start and end of the cable
        Vector3 point1Position = point1.position + new Vector3(0.48f, 0, -0.95f);
        Vector3 point2Position = point2.position + new Vector3(-0.48f, 0, -0.95f);
        // Calculate the position and rotation of the cable
        Vector3 midpoint = (point1Position + point2Position) / 2f;
        Quaternion rotation = Quaternion.LookRotation(point2Position - point1Position);
        rotation *= Quaternion.Euler(90f, 0f, 0f);
        float distance = Vector3.Distance(point1Position, point2Position);

        // Create the cable
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position = midpoint;
        cylinder.transform.rotation = rotation;
        cylinder.transform.localScale = new Vector3(0.1f, distance / 2f, 0.1f);

        // Set the parent of the cable
        if (parent != null)
        {
            cylinder.transform.parent = parent;
        }
        // Apply the texture to the cable
        Renderer cylinderRenderer = cylinder.GetComponent<Renderer>();
        if (cylinderRenderer != null)
        {
            cylinderRenderer.material = cylinderMaterial;
        }
    }
    void DeleteCylinder()
    {
        // Destroy the cable if necessary
        if (cylinder != null)
        {
            Destroy(cylinder);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && ismousedown)
        {
            //Check where the mouse went up
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Create a layer mask that includes all layers except the "Ignore Raycast" layer
            int ignoreRaycastLayer = 1 << 2; // Layer index 2
            int layerMask = ~ignoreRaycastLayer;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                // Check if the clicked object is the targetObject in cableEnd
                if (hit.collider.gameObject == cableEnd.targetObject)
                {
                    // The mouse button is released on the target object
                    Debug.Log("Mouse up on: " + cableEnd.name);
                    SpawnObject();
                    // Notify the CableManager that a cable is connected
                    cableManager.CableConnected();
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
