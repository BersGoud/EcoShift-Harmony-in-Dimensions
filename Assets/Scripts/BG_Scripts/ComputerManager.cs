using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComputerManager : CanvasManagerBase
{
    public static bool GameIsPaused = false;
    public GameObject ComputerPanel;
    void Start()
    {
        Debug.Log("ComputerManager Start method called");
        ComputerPanel.SetActive(false);
    }

    public override void Show(bool disableMovement = true)
    {
        Debug.Log("Show method called in ComputerManager");
        base.Show(disableMovement);
        Time.timeScale = 0f;
        GameIsPaused = true;
        ComputerPanel.SetActive(true);
    }

    public override void Hide(bool enableMovement = true)
    {
        base.Hide(enableMovement);
        Time.timeScale = 1f;
        GameIsPaused = false;
        ComputerPanel.SetActive(false);
    }

    public void Close()
    {
        // This method is used to close the scene (you can implement it as needed)
        Hide();
    }
}

