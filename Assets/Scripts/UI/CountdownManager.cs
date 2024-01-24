using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class CountdownManager : CanvasManagerBase
    {
        public int countdownSeconds = 30;

        public TextMeshProUGUI CountdownText;
        public GameOverManager gameOver;

        private Coroutine GameOverCouritine;
        public void StartCountdown()
        {
            GameOverCouritine = StartCoroutine(CountDown());
        }

        public void StopCountdown()
        {
            if (GameOverCouritine != null)
                StopCoroutine(GameOverCouritine);
        }

        public IEnumerator CountDown()
        {
            for (int i = countdownSeconds; i >= 0; i--)
            {
                this.ShowCounter(i);
                yield return new WaitForSeconds(1f);
            }
            //If we haven't delivered the books slow down time and show the game over UI.
            Time.timeScale = 1F;
            do
            {
                yield return new WaitForSeconds(0.1F);
                Time.timeScale -= 0.1F;
            } while (Time.timeScale > 0.1);
            Time.timeScale = 0F;
            gameOver.ShowGameOverText("Try to be faster next time!");
            Time.timeScale = 1F;
        }
        public void ShowCounter(int counter)
        {
            CountdownText.text = counter.ToString();
            this.Show(false);
        }
    }
}