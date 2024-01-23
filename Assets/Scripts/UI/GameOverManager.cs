using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class GameOverManager : CanvasManagerBase
    {
        public TextMeshProUGUI Reason;
        public void ShowGameOverText(string reason)
        {
            Reason.text = reason;
            this.Show();
        }
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}