using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shows the interaction prompt and calls Interact on IInteractable objects.
/// </summary>

public class InteractionPrompt : MonoBehaviour
{
    private Transform _camera;
    public float Range;
    // Start is called before the first frame update
    void Start()
    {
        _camera = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Draw a raycast from the camera
        Ray r = new Ray(_camera.position, _camera.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, Range))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                //If it hits an interactable object, show UI prompt
                //TODO
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //If E is pressed when the prompt is showing: Call Interact() on the object
                    interactObj.Interact();
                }
            }
        }
    }
}
