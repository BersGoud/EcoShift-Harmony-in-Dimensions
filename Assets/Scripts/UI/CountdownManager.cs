using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class CountdownManager : CanvasManagerBase
    {
        public TextMeshProUGUI CountdownText;
        public void ShowCounter(int counter)
        {
            CountdownText.text = counter.ToString();
            this.Show(false);
        }
    }
}