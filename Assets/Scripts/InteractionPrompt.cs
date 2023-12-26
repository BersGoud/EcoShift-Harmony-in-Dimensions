using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows the interaction prompt and calls Interact on IInteractable objects.
/// </summary>

public class InteractionPrompt : MonoBehaviour
{
    public Transform Camera;
    public float Range;
    public GameObject InteractionCanvas;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Draw a raycast from the camera
        Ray r = new Ray(Camera.position, Camera.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, Range))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                //If it hits an interactable object, show UI prompt
                string text = interactObj.GetInteractionText();
                InteractionCanvas.GetComponentInChildren<TextMeshProUGUI>().text = text;
                InteractionCanvas.SetActive(true);
                //TODO
                if (Input.GetKeyDown(interactObj.GetInteractionKey()))
                {
                    //If E is pressed when the prompt is showing: Call Interact() on the object
                    string pressedText = interactObj.Interact();
                    if (pressedText != null)
                        InteractionCanvas.GetComponentInChildren<Text>().text = pressedText;
                }
            }
        } else
        {
            InteractionCanvas.SetActive(false);
        }
    }
}
