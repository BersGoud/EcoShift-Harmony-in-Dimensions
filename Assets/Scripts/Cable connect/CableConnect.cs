using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableConnect : MonoBehaviour
{
    public CableManager cableManager; // Drag the GameObject with the CableManager script to this field
    public CableEnd objectA;
    public Transform point1;
    public Transform point2;
    public Transform parent;
    public Material cylinderMaterial;
    private bool ismousedown = false;
    private GameObject cylinder;
    public void OnMouseDown() 
    {
        Debug.Log("Mouse down on: " + gameObject.name);
        ismousedown = true;
    }
    // void Start()
    // {
    //     StartCoroutine(UpdateCylinder());
    // }

    // IEnumerator UpdateCylinder()
    // {
    //     while (true)
    //     {
    //         CreateCylinder();
    //         yield return new WaitForSeconds(1.0f); // Change this value to control the update frequency
    //         DeleteCylinder();
    //     }
    // }
    public void SpawnObject()
    {
        Vector3 point1Position = point1.position + new Vector3(0.48f, 0, -0.95f);
        Vector3 point2Position = point2.position + new Vector3(-0.48f, 0, -0.95f);
        // Calculate the position and rotation of the cylinder
        Vector3 midpoint = (point1Position + point2Position) / 2f;
        Quaternion rotation = Quaternion.LookRotation(point2Position - point1Position);
        rotation *= Quaternion.Euler(90f, 0f, 0f);
        float distance = Vector3.Distance(point1Position, point2Position);

        // Create the cylinder
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position = midpoint;
        cylinder.transform.rotation = rotation;
        cylinder.transform.localScale = new Vector3(0.1f, distance / 2f, 0.1f);

        // Set the parent of the cylinder
        if (parent != null)
        {
            cylinder.transform.parent = parent;
        }
        // Apply the texture to the cylinder
        Renderer cylinderRenderer = cylinder.GetComponent<Renderer>();
        if (cylinderRenderer != null)
        {
            cylinderRenderer.material = cylinderMaterial;
        }
    }
    void DeleteCylinder()
    {
        if (cylinder != null)
        {
            Destroy(cylinder);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
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
