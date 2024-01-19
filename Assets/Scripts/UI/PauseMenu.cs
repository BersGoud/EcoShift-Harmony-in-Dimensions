using Assets.Scripts.UI;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : CanvasManagerBase
{
    public static bool GameIsPaused = false;
    public GameObject PauseCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
    }

    public override void Show(bool disableMovement = true)
    {
        base.Show(disableMovement);
        Time.timeScale = 0f;
        GameIsPaused = true; 
    }

    public override void Hide(bool enableMovement = true)
    {
        base.Hide(enableMovement);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void CloseScene()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("UI");
    }
}
