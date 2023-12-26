using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering.PostProcessing;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] _lines;
    private int _currentIndex;
    private bool _typing = false;

    private TextMeshProUGUI DialogueText;

    public float TextSpeedSeconds;
    /// <summary>
    /// Allow clicking of the dialogue to go to the next text.
    /// Disable to do this manually.
    /// </summary>
    public bool clickToSkip = true;

    public void DisplayDialogue(string[] lines, Action<int> lineDone = null)
    {
        if (DialogueText == null)
            this.DialogueText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        gameObject.SetActive(true);

        _lines = lines;
        StartCoroutine(TypeLine());
        if (lineDone != null)
            lineDone(_currentIndex);
    }

    public void DisplayNext(float waitTimeSeconds = 0)
    {
        if (_lines.Length - 1 > _currentIndex)
        {
            _currentIndex++;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine(float waitTimeSeconds = 0)
    {
        DialogueText.text = "";
        _typing = true;
        yield return new WaitForSeconds(waitTimeSeconds);
        foreach (char character in _lines[_currentIndex].ToCharArray())
        {
            DialogueText.text += character;
            yield return new WaitForSeconds(TextSpeedSeconds);
        }
        _typing = false;
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_typing && clickToSkip)
        {
            DisplayNext();
        }
    }
}
