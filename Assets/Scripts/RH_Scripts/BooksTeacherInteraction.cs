using Assets.Scripts.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksTeacherInteraction : Interaction
{
    private RH_LevelSetup _setup;
    private void Start()
    {
        _setup = GameObject.FindFirstObjectByType<RH_LevelSetup>();
    }
    public override string Interact()
    {
        _setup.BooksInventory++;
        return base.Interact();
    }
    private void DisableBookOnTop()
    {

    }
}
