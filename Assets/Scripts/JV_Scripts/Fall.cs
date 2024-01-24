using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Fall : MonoBehaviour
{
    // Restarts level when player falls
    public string sceneToLoad = "Level_JV_2"; 
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
