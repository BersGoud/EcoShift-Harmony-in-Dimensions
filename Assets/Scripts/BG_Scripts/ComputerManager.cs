using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class ComputerManager : CanvasManagerBase
{
    public static bool GameIsPaused = false;
    public GameObject ComputerPanel;
    public GameObject character; // Reference to the character GameObject
    public GameObject stuff;


    public Button networkManagerButton; // Reference to the NetworkManager button
    public TextMeshProUGUI messageBox; // Reference to the MessageBox text
    public GameObject laptop;

    protected override void Start()
    {
        Debug.Log("ComputerManager Start method called");
        ComputerPanel.SetActive(false);

        // Disable the NetworkManager button initially
        networkManagerButton.interactable = false;
    }

    public override void Show(bool disableMovement = true)
    {
        Debug.Log("Show method called in ComputerManager");
        base.Show(disableMovement);
        Time.timeScale = 0f;
        GameIsPaused = true;
        ComputerPanel.SetActive(true);

        // Check if the Breaker script is active and its boolean is true
        breakerinteract breakerScript = Object.FindObjectOfType<breakerinteract>(true);
        if (breakerScript != null && breakerScript.IsStartButtonClicked)
        {
            // Enable the NetworkManager button
            networkManagerButton.interactable = true;
        }
        else
        {
            // Disable the NetworkManager button
            networkManagerButton.interactable = false;
            // Set message in red in the MessageBox
            messageBox.text = "Breaker is not active";
            messageBox.color = Color.red;
        }
    }

    public override void Hide(bool enableMovement = true)
    {
        base.Hide(enableMovement);
        Time.timeScale = 1f;
        GameIsPaused = false;
        ComputerPanel.SetActive(false);
    }

    public void NetworkManager()
    {
        breakerinteract breakerScript = Object.FindObjectOfType<breakerinteract>(true);
        if (breakerScript != null && breakerScript.IsStartButtonClicked)
        {
            // Disable character and enable ConnectFour
            character.SetActive(false);
            ComputerPanel.SetActive(false);
            stuff.SetActive(true);
            laptop.SetActive(false);
        }
    }

    public void Close()
    {
        // This method is used to close the scene (you can implement it as needed)
        Hide();
    }
}


