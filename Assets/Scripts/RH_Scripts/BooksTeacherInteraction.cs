using Assets.Scripts.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksTeacherInteraction : RH_InteractionBase
{
    private int totalBooks;
    protected override void Start()
    {
        totalBooks = gameObject.transform.childCount;
        base.Start();
    }
    public override string GetInteractionText()
    {
        if (totalBooks > 0)
        {
            return base.GetInteractionText();
        } else
        {
            return string.Empty;
        }
    }
    public override string Interact()
    {
        if (totalBooks > 0)
        {
            _setup.BooksInventory++;
            DisableBookOnTop();
        }
        return base.Interact();
    }
    private void DisableBookOnTop()
    {
        totalBooks--;
        gameObject.transform.GetChild(totalBooks).gameObject.SetActive(false);
    }
}
