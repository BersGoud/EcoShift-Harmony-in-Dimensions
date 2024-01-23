using Assets.Scripts.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class breakerinteract : CanvasManagerBase
{
    public static bool GameIsPaused = false;
    public GameObject solarPanel1;
    public GameObject solarPanel2;
    public GameObject breakerUI;
    public TMP_InputField serialNumberField1;
    public TMP_InputField serialNumberField2;
    public TextMeshProUGUI resultText;

    private bool isStartButtonClicked = false;
    private Animator animator1;
    private Animator animator2;
    public AudioSource correctSound;

    private bool isCoroutineRunning = false;

    public bool IsStartButtonClicked
    {
        get { return isStartButtonClicked; }
    }

    // Start is called before the first frame update
    void Start()
    {
        breakerUI.SetActive(false);
        // Deactivate the animations initially
        animator1 = solarPanel1.GetComponent<Animator>();
        animator2 = solarPanel2.GetComponent<Animator>();
        animator1.speed = 0f;
        animator2.speed = 0f;
    }

    public override void Show(bool disableMovement = true)
    {
        Debug.Log("Show method called in breaker");
        base.Show(disableMovement);
        Time.timeScale = 0f;
        GameIsPaused = true;
        breakerUI.SetActive(true);
        string serialNumber1 = serialNumberField1.text;
        string serialNumber2 = serialNumberField2.text;
        if (serialNumber1.Equals("AZ02", StringComparison.OrdinalIgnoreCase) && serialNumber2.Equals("AZ01", StringComparison.OrdinalIgnoreCase))
        {
            resultText.text = "System nominal, solar panels in operation";
            resultText.color = new Color(0, 255, 23, 255);
        }
        else
        {
            resultText.text = "Serial numbers are incorrect, systems are down";
            resultText.color = new Color(255, 0, 0, 255);
        }
    }

    public override void Hide(bool enableMovement = true)
    {
        base.Hide(enableMovement);
        Time.timeScale = 1f;
        GameIsPaused = false;
        breakerUI.SetActive(false);
    }

    public void OnStartButtonClicked()
    {
        string serialNumber1 = serialNumberField1.text;
        string serialNumber2 = serialNumberField2.text;
        Debug.Log($"Values of s1: {serialNumber1}, and s2: {serialNumber2}");

        if (serialNumber1.Equals("AZ02", StringComparison.OrdinalIgnoreCase) && serialNumber2.Equals("AZ01", StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("Method breaker start is loading ... true");
            resultText.text = "Correct, starting up solar panels...";
            resultText.color = new Color(0, 255, 23, 255);

            // Start coroutines to freeze animations after 10 seconds
            animator1.speed = 1f;
            animator2.speed = 1f;
            correctSound.volume = 0.7f;
            correctSound.loop = false;

            // Play the correct sound
            if (correctSound != null)
            {
                correctSound.Play();
            }

            // Start coroutines only if they are not running
            if (!isCoroutineRunning)
            {
                StartCoroutine(FreezeAnimationsCoroutine(animator1));
                StartCoroutine(FreezeAnimationsCoroutine(animator2));

                // Set the flag to indicate that the coroutines are running
                isCoroutineRunning = true;
            }

            // Set the property to true when conditions are met
            isStartButtonClicked = true;
            serialNumberField1.interactable = false;
            serialNumberField2.interactable = false;

        }
        else
        {
            Debug.Log("Method breaker start is loading ... false");
            resultText.text = "Serial numbers are incorrect";
            resultText.color = new Color(255, 0, 0, 255);
            // Set the property to false when conditions are not met
            isStartButtonClicked = false;
        }
    }

    public void Close()
    {
        // This method is used to close the scene (you can implement it as needed)
        Hide();
    }

    public void GetLatestValueParam1(string s)
    {
       Debug.Log(s);
       serialNumberField1.text = s;
    }

    public void GetLatestValueParam2(string s)
    {
        Debug.Log(s);
        serialNumberField2.text = s;
    }

    public IEnumerator FreezeAnimationsCoroutine(Animator animator)
    {
        yield return new WaitForSeconds(10.0f);

        // Freeze the animation
        animator.speed = 0f;

        // Set the flag to indicate that the coroutine has finished
        isCoroutineRunning = false;
    }
}
