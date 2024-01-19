using Assets.Scripts.Interaction;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class KeyPadInteraction : RH_InteractionBase
{
    public RH_LevelSetup RH;
    public override string Interact()
    {
        RH.Director.Play(RH.DoorOpen);
        RH.Director.stopped += Director_stopped;
        return base.Interact();
    }

    private void Director_stopped(PlayableDirector obj)
    {
        SceneManager.LoadScene("Level_BG");
    }
}
