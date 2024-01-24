using Assets.Scripts.Interaction;
using Assets.Scripts.RH_Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteraction : RH_InteractionBase
{
    public bool HasDelivered = false;
    private ChangeTransparency transparency;
    private BooksTeacherInteraction teacherInteraction;
    public LaptopInteraction LaptopInteraction;
    protected override void Start()
    {
        transparency = gameObject.GetComponent<ChangeTransparency>();
        teacherInteraction = GameObject.FindFirstObjectByType<BooksTeacherInteraction>();
        base.Start();
    }
    public override string Interact()
    {
        if (!HasDelivered && _setup.BookDelivered(this))
        {
            transparency.Alpha = 1;
            teacherInteraction.DisableBookInHand();
            return base.Interact();
        } else if (transparency.Alpha != 1)
        {
            LaptopInteraction.AllowInteraction = true;
            teacherInteraction.DisableBookInHand();
        }
        return "";
    }
    public override string GetInteractionText()
    {
        if (!HasDelivered)
            return base.GetInteractionText();
        else
            return "";
    }
}
