using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelectLevel : MonoBehaviour
{
    public void OnClick(string sceneName)
    {
        Debug.Log("This is a log message in Start()");
        SceneManager.LoadScene(sceneName);
    }
}
