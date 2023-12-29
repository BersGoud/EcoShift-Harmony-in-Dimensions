using Assets.Scripts.Interaction;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopInteraction : RH_InteractionBase
{
    public Canvas LaptopUI;
    public ThirdPersonController Player;
    public BooksTeacherInteraction teacherInteraction;
    public override string Interact()
    {
        LaptopUI.enabled = true;
        Player.CameraMovementEnabled = false;
        return base.Interact();
    }
}
