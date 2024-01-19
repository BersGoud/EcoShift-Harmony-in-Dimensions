using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    public float interactionDistance = 3f;
    public TMP_Text interactionText;
    public GameObject infoPanel; // Reference to the UI Panel
    public TMP_Text infoText; // Reference to the TextMeshPro Text inside the panel
    public string customInfoText = "Welcome to the game! Here are some tips...";

    private bool isPanelOpen = false;

    void Start()
    {
        // Make sure the infoPanel is initially inactive
        infoPanel.SetActive(false);
    }

    void Update()
    {
        // Assume the player is represented by a GameObject with a Collider (e.g., a character controller)
        Collider playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();

        float distance = Vector3.Distance(transform.position, playerCollider.transform.position);

        if (distance < interactionDistance)
        {
            // Player is within interaction distance
            Vector3 textPosition = transform.position + Vector3.up * 2f; // Adjust the Y value as needed

            // Convert world position to screen space
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(textPosition);

            // Set the TextMeshPro text position
            interactionText.rectTransform.position = screenPosition;

            interactionText.text = isPanelOpen ? "Press E to close" : "Press E to interact";
            interactionText.gameObject.SetActive(true);

            // Check for input (e.g., E key press) to toggle the interaction
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleInfoPanel();
            }
        }
        else
        {
            // Player is outside interaction distance
            interactionText.gameObject.SetActive(false);
            // Hide the info panel when not interacting
            if (isPanelOpen)
            {
                ToggleInfoPanel();
            }
        }
    }

    void ToggleInfoPanel()
    {
        isPanelOpen = !isPanelOpen;
        infoPanel.SetActive(isPanelOpen);
        infoText.text = isPanelOpen ? customInfoText : string.Empty;
    }
}
