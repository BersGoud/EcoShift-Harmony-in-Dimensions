using Assets.Scripts.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttontest : Interaction
{
    public Material testmaterial;
    private Renderer rend;
    public override string Interact()
    {
        // Code for interaction
        rend = GetComponent<Renderer>();
        rend.material = testmaterial;
        return base.Interact();
    }
    // Update is called once per frame
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
