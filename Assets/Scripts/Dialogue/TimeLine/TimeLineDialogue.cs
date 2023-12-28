using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Assets.Scripts.Dialogue.TimeLine
{
    [Serializable]
    public class TimeLineDialogue : PlayableAsset, ITimelineClipAsset
    {

        [SerializeField]
        public PlayableDialogue template = new PlayableDialogue();

        public ClipCaps clipCaps
        {
            get
            {
                return ClipCaps.None;
            }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<PlayableDialogue>.Create(graph, template);
        }
    }
}