using Assets.Scripts.Dialogue.DialogueClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    private DialogueBox[] _lines;
    private int _currentIndex;
    private bool _typing = false;

    private RectTransform PanelTransform;
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI SpeakerText;

    public float TextSpeedSeconds;
    /// <summary>
    /// Allow clicking of the dialogue to go to the next text.
    /// Disable to do this manually.
    /// </summary>
    public bool clickToSkip = true;

    public void DisplayDialogue(DialogueBox[] lines, Action<int> lineDone = null)
    {
        if (PanelTransform == null)
            PanelTransform = gameObject.GetComponent<RectTransform>();
        gameObject.SetActive(true);

        _lines = lines;
        StartCoroutine(TypeText(_lines[_currentIndex]));
        if (lineDone != null)
            lineDone(_currentIndex);
    }

    public void DisplayNext()
    {
        if (_currentIndex < _lines.Length - 1)
        {
            _currentIndex++;
            StartCoroutine(TypeText(_lines[_currentIndex]));
        }
        else
        {
            gameObject.SetActive(false);
            _currentIndex = 0;
        }
    }

    public IEnumerator TypeText(DialogueBox dialogue)
    {
        gameObject.SetActive(true);
        DialogueText.text = "";
        _typing = true;
        SpeakerText.text = dialogue.SpeakerName;
        foreach (char character in dialogue.Text.ToCharArray())
        {
            DialogueText.text += character;
            yield return new WaitForSeconds(TextSpeedSeconds);
        }
        _typing = false;
    }

    public void TypeLetter(DialogueBox dialogue, double currentTime)
    {
        if (dialogue.Centered)
        {
            DialogueText.horizontalAlignment = HorizontalAlignmentOptions.Center;
            DialogueText.verticalAlignment = VerticalAlignmentOptions.Middle;
        } else
        {
            DialogueText.horizontalAlignment = HorizontalAlignmentOptions.Left;
            DialogueText.verticalAlignment = VerticalAlignmentOptions.Top;
        }

        SpeakerText.text = dialogue.SpeakerName;

        gameObject.SetActive(true);

        if (dialogue.Text.Length > 0) {
            //delta per character.
            float delta = (float)((dialogue.Duration - dialogue.Wait) / dialogue.Text.Length);
            int index = (int)(currentTime / delta) + 1;

            if (index >= dialogue.Text.Length)
                index = dialogue.Text.Length;
            DialogueText.text = dialogue.Text.Substring(0, index);
        }
        else
        {
            DialogueText.text = "";
        }
    }

    public void HideDialogue()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_typing && clickToSkip && _lines != null && _lines.Length > 0)
        {
            DisplayNext();
        }
    }
}
