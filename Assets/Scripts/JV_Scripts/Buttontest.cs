using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttontest : MonoBehaviour
{
    public Material testmaterial;
    private Renderer rend;
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the cube
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Cube is clicked
                rend = GetComponent<Renderer>();
                rend.material = testmaterial;
            }
        }
    }
}
