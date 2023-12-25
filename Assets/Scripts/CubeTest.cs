using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTest : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("E was pressed on this object!");
    }
}
