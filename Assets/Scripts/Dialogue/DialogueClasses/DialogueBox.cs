using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Dialogue.DialogueClasses
{
    [Serializable]
    public struct DialogueBox
    {
        public string SpeakerName;
        public string Text;
        public bool Centered;
        public double Wait;
        [NonSerialized]
        public double Duration;
    }
}