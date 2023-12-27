using System.Collections;
using UnityEngine;
using UnityEngine.Timeline;

namespace Assets.Scripts.Dialogue.TimeLine
{
    [TrackColor(30 / 255f, 30 / 255f, 200 / 255f)]
    [TrackBindingType(typeof(DialogueSystem))]
    [TrackClipType(typeof(TimeLineDialogue))]
    public class TrackDialogue : TrackAsset
    {

    }
}