using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;



public class SolarPanelInteract : MK_InteractionBase
{
    
    public ThirdPersonController player;
    public GameObject bolt;
    public GameObject powerBoard;
    public Material boltOnMaterial;
    private bool buttonClicked = false;

    private AudioSource _source;
    // Start is called before the first frame update

    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        // Subscribe to the sceneUnloaded event
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from the sceneUnloaded event
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    public override string Interact()
    {
        _setup.gameManager.StartMiniGame("Level_MK");
        buttonClicked = true;
        player.CameraMovementEnabled = false;
        return base.Interact();

    }
    private void OnSceneUnloaded(Scene scene)
    {
        Debug.Log(scene.name);
        // Check if the unloaded scene is the minigame scene
        if (scene.name == "Level_JV" && buttonClicked)
        {
       
            if (_setup.gameManager.IsMiniGameCompleted())
            {
                Debug.Log("minigame completed");
                
                player.CameraMovementEnabled = true;
                Debug.Log("Activated player movement");
                
                ActivatePower();
                buttonClicked = false;
            }
        }
    }

    private void ActivatePower()
    {
        //activate bolt
        Debug.Log("Activating bolt");
        
        if (bolt != null)
        {
            // Get the Renderer component of the "bolt" object
            Renderer boltRenderer = bolt.GetComponent<Renderer>();
            Debug.Log("Found renderer");
            

            if (boltRenderer != null && boltOnMaterial != null)
            {
                // Change the material to the new one
                boltRenderer.material = boltOnMaterial;
                Debug.Log("Changed material");
                
            }
            else
            {
                Debug.LogError("Renderer on the 'bolt' object or new material is not assigned.");
            }
        }
        //activate shift power
        _setup.getShift().isDimensionalShiftEnabled = true;
        _source.Play();
        
        //show new sign

        powerBoard.SetActive(true);
        
        
    }
}
