using Assets.Scripts.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteraction : Interaction
{
    public bool RecycledBook = true;
    public bool HasDelivered = false;
    private RH_LevelSetup _setup;
    private void Start()
    {
        _setup = GameObject.FindFirstObjectByType<RH_LevelSetup>();
    }
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
