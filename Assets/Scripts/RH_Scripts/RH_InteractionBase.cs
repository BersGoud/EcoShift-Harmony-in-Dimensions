using Assets.Scripts.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RH_InteractionBase : Interaction
{
    protected RH_LevelSetup _setup;
    private void Start()
    {
        _setup = GameObject.FindFirstObjectByType<RH_LevelSetup>();
    }
}
