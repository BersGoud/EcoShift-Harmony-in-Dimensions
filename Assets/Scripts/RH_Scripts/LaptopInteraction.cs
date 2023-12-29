using Assets.Scripts.Interaction;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopInteraction : RH_InteractionBase
{
    public LaptopUI LaptopUI;
    public override string Interact()
    {
        LaptopUI.EnableUI();
        return base.Interact();
    }
}
