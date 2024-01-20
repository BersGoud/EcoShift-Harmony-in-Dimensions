using Assets.Scripts.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pc_Interact : Interaction
{
    public ComputerManager ComputerUI;
    public override string Interact()
    {
        ComputerUI.Show();
        return base.Interact();
    }
}
