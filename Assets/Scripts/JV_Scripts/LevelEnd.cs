using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public JV_LevellSetup JV;

    private void OnTriggerEnter(Collider other)
    {
        JV.endingCanvas.Show();
    }
}