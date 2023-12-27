using Assets.Scripts.Dialogue.DialogueClasses;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

namespace Assets.Scripts.Dialogue.TimeLine
{
    [Serializable]
    public class PlayableDialogue : PlayableBehaviour
    {
        [SerializeField]
        public DialogueBox Dialogue = new DialogueBox();

        private DialogueSystem system;

        public override void ProcessFrame(Playable playable, FrameData info, object data)
        {
            base.ProcessFrame(playable, info, data);

            system = data as DialogueSystem;

            Dialogue.Duration = playable.GetDuration();
            system.TypeLetter(Dialogue, playable.GetTime());
        }
        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            if (system != null)
                system.HideDialogue();
            base.OnBehaviourPause(playable, info);
        }
    }
}