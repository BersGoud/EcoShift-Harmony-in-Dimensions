using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;



public class SolarPanelInteract : MK_InteractionBase
{
    
    [Header("Objects from outside")]
    public ThirdPersonController player;
    public GameObject bolt;
    public GameObject powerBoard;
    public Material boltOnMaterial;
    
    [Header("Parameters")]
    private bool buttonClicked = false;
    private AudioSource _source;
    // Start is called before the first frame update

    //gets excecuted before everything else
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
        _setup.gameManager.StartMiniGame("Level_MK"); //starts the cable minigame
        buttonClicked = true;
        AllowInteraction = false;
        player.CameraMovementEnabled = false; //disables player movement
        return base.Interact();

    }
    private void OnSceneUnloaded(Scene scene)
    {
        Debug.Log(scene.name);
        // Check if the unloaded scene is the minigame scene
        if (scene.name == "Level_JV" && buttonClicked)
        {
            //checks if minigame scene is completed. if so, activate powers
            if (_setup.gameManager.IsMiniGameCompleted())
            {
                player.CameraMovementEnabled = true;
                ActivatePower();
                buttonClicked = false;
            }
        }
    }

    /// <summary>
    /// This piece of code got added for readability. It changes materials of an object,
    /// plays a sound and enables the Shift power for the player. Also makes a newµ
    /// sign appear so that the player gets more info on what happened.
    /// </summary>
    /// <returns></returns>
    private void ActivatePower()
    {
        //make bolt yellow
        if (bolt != null)
        {
            Renderer boltRenderer = bolt.GetComponent<Renderer>();
            if (boltRenderer != null && boltOnMaterial != null)
            {
                boltRenderer.material = boltOnMaterial;
            }
            else
            {
                Debug.LogError("Renderer on the 'bolt' object or new material is not assigned.");
            }
        }
        //activate shift power
        _setup.getShift().isDimensionalShiftEnabled = true;
        //play sound
        _source.Play();
        //show new sign
        powerBoard.SetActive(true);
        
        
    }
}
