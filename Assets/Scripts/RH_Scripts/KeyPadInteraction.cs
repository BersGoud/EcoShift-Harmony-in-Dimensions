using Assets.Scripts.Interaction;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadInteraction : Interaction
{

    public override string Interact()
    {
        Debug.Log("E was pressed on this object!");
        return base.Interact();
    }
}
