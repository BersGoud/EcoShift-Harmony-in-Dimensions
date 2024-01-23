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

    private TextMeshProUGUI _interactText;
    private bool isPressedTextShown = false;
    // Start is called before the first frame update
    void Start()
    {
        _interactText = InteractionCanvas.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //Draw a raycast from the camera
        Ray r = new Ray(Camera.position, Camera.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, Range))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj) && interactObj.GetEnabled())
            {
                //If it hits an interactable object, show UI prompt
                string text = interactObj.GetInteractionText();
                if (!isPressedTextShown)
                    _interactText.text = text;
                InteractionCanvas.SetActive(true);

                if (Input.GetKeyDown(interactObj.GetInteractionKey()))
                {
                    //If E is pressed when the prompt is showing: Call Interact() on the object
                    string pressedText = interactObj.Interact();
                    if (pressedText != string.Empty)
                    {
                        _interactText.text = pressedText;
                        isPressedTextShown = true;
                    }
                }
            }
            else
            {
                InteractionCanvas.SetActive(false);
                isPressedTextShown = false;
            }
        }
        else
        {
            InteractionCanvas.SetActive(false);
            isPressedTextShown = false;
        }
    }
}
