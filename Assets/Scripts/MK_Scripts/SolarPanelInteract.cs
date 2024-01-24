
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SolarPanelInteract : MK_InteractionBase
{
    private bool buttonClicked = false;
    // Start is called before the first frame update

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
        Debug.Log("interacted");
        return "";
        
    }
    private void OnSceneUnloaded(Scene scene)
    {
        Debug.Log(scene.name);
        // Check if the unloaded scene is the minigame scene
        if (scene.name == "Level_JV" && buttonClicked)
        {
       
            if (_setup.gameManager.IsMiniGameCompleted())
            {
                // SpawnObject();
                buttonClicked = false;
            }
        }
    }
}
