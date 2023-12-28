using Assets.Scripts.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteraction : RH_InteractionBase
{
    public bool RecycledBook = true;
    public bool HasDelivered = false;
    public override string Interact()
    {
        if (!HasDelivered && _setup.BookDelivered(this))
        {
            HasDelivered = true;
            gameObject.GetComponent<ChangeTransparency>().Alpha = 1;
            return base.Interact();
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
