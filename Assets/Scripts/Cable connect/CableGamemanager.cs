using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CableGamemanager
{
    // Allows for CableGamemanager to be created in other scenes
    private static CableGamemanager instance;
    public static CableGamemanager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CableGamemanager();
            }
            return instance;
        }
    }
    // Game progress variables
    private bool miniGameCompleted = false;
    private bool minibool = false;
    private string minigamelevel = "Level_JV";
    private string originallevel = "Level_JV_2";
    public void StartMiniGame(string level = "Level_JV_2")
    {
        // Start the minigame as an additive scene
        originallevel = level;
        minibool = false;
        SceneManager.LoadScene(minigamelevel, LoadSceneMode.Additive);
    }
    public void SetMiniGameCompleted()
    {
        // Set the game progress variable to true when the mini-game is completed
        miniGameCompleted = true;
        Debug.Log(miniGameCompleted);
        SceneManager.UnloadSceneAsync(minigamelevel);
    }

    public bool IsMiniGameCompleted()
    {
        // Check the game progress variable to determine if the mini-game is completed
        minibool = miniGameCompleted;
        miniGameCompleted = false;
        return minibool;
    }
}