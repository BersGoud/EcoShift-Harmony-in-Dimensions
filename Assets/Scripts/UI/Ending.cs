using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : CanvasManagerBase
{
    public string buttonText = "Back to the main menu";
    public string nextLevelName = "UI";
    public TMP_Text text;
    protected override void Start()
    {
        base.Start();
        text.text = buttonText;
    }
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
