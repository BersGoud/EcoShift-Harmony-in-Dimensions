using Assets.Scripts.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_base : Interaction
{
    public breakerinteract breakerUI;
    public override string Interact()
    {
        breakerUI.Show();
        return base.Interact();
    }
}
