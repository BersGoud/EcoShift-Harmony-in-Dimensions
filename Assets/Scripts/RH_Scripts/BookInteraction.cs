using Assets.Scripts.Interaction;
using Assets.Scripts.RH_Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteraction : RH_InteractionBase
{
    public bool HasDelivered = false;
    private BooksTeacherInteraction teacherInteraction;
    protected override void Start()
    {
        teacherInteraction = GameObject.FindFirstObjectByType<BooksTeacherInteraction>();
        base.Start();
    }
    public override string Interact()
    {
        if (!HasDelivered && _setup.BookDelivered(this))
        {
            gameObject.GetComponent<ChangeTransparency>().Alpha = 1;
            teacherInteraction.DisableBookInHand();
            return base.Interact();
        } else
        {
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
