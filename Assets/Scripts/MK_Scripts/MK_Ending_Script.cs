using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.UI;

public class MK_Ending_Script : MonoBehaviour
{
    public Ending endGameScreen;
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player (you can customize the player tag or layer)
        if (other.CompareTag("Player"))
        {
            endGameScreen.Show();

        }
    }
}
