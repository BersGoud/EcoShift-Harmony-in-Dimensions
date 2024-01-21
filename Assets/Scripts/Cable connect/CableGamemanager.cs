using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CableGamemanager
{
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
    // Game progress variable
    private bool miniGameCompleted = false;
    private bool minibool = false;
    private string minigamelevel = "Level_JV";
    private string originallevel = "Level_JV_2";

    public void StartMiniGame(string level)
    {
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

        // Add any other logic you want to execute when the mini-game is completed
    }

    public bool IsMiniGameCompleted()
    {
        // Check the game progress variable to determine if the mini-game is completed
        minibool = miniGameCompleted;
        miniGameCompleted = false;
        return minibool;
    }
}