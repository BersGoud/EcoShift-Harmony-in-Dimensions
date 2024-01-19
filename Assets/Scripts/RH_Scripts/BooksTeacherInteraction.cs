using Assets.Scripts.Interaction;
using Assets.Scripts.RH_Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksTeacherInteraction : RH_InteractionBase
{
    public int TotalBooks;
    public GameObject bookInHand;
    public bool RecycledBook = true;
    protected override void Start()
    {
        TotalBooks = gameObject.transform.childCount;
        base.Start();
    }
    public override string GetInteractionText()
    {
        if (TotalBooks > 0)
        {
            return base.GetInteractionText();
        } else
        {
            return string.Empty;
        }
    }
    public override string Interact()
    {
        if (TotalBooks > 0 && _setup.BooksInventory < 1)
        {
            _setup.GiveBook(new Book(RecycledBook));
            DisableBookOnTop();
            EnableBookInHand();
        }
        return base.Interact();
    }
    public void DisableBookInHand()
    {
        bookInHand.SetActive(false);
        this.AllowInteraction = true;
    }
    public void EnableBookInHand()
    {
        bookInHand.SetActive(true);
        this.AllowInteraction = false;
    }
    private void DisableBookOnTop()
    {
        TotalBooks--;
        gameObject.transform.GetChild(TotalBooks).gameObject.SetActive(false);
    }
    public void EnableBookOnBottom(bool isBookRecyled)
    {
        gameObject.transform.GetChild(TotalBooks).gameObject.SetActive(true);
        TotalBooks++;
        RecycledBook = isBookRecyled;
    }
}
