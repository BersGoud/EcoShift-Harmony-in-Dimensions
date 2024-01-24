using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Interaction;
using StarterAssets;

public class MK_InteractionBase : Interaction
{
    /// <summary>
    /// A class implemented incase i wanted to expand on the interactive functionability in the future
    /// </summary>
    protected Level_Setup_MK _setup;
    protected virtual void Start()
    {
        _setup = GameObject.FindFirstObjectByType<Level_Setup_MK>();
    }
}

