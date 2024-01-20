using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableManager : MonoBehaviour
{
    private int cablesConnected = 0;
    CableGamemanager gameManager = CableGamemanager.Instance;

    // Called when any cable is connected
    public void CableConnected()
    {
        cablesConnected++;

        // Check if all four buttons are pressed
        if (cablesConnected == 4)
        {
            // Change the color of the ButtonManager GameObject
            GetComponent<Renderer>().material.color = Color.green;
            gameManager.SetMiniGameCompleted();
        }
    }
}