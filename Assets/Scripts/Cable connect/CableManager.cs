using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableManager : MonoBehaviour
{
    public Transform[] objects;
    public Transform[] ends;
    private List<float> ycoords = new List<float>();
    private List<float> ycoords2 = new List<float>();
    private int cablesConnected = 0;
    CableGamemanager gameManager = CableGamemanager.Instance;
    public void Start()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            // Create list y coordinates to shuffle
            Vector3 pos = objects[i].position;
            ycoords.Add(pos.y);
            Vector3 pos2 = ends[i].position;
            ycoords2.Add(pos2.y);
        }
        ShuffleY<float>(ycoords);
        ShuffleY<float>(ycoords2);
        for (int i = 0; i < objects.Length; i++)
        {
            // Change the positions of the start and end objects
            Vector3 newPosition = objects[i].position;
            newPosition.y = ycoords[i];
            objects[i].position = newPosition;
            Vector3 newPosition2 = ends[i].position;
            newPosition2.y = ycoords2[i];
            ends[i].position = newPosition2;
        }
    }
    // Called when any cable is connected
    public void CableConnected()
    {
        cablesConnected++;

        // Check if all four cables are connected
        if (cablesConnected == 4)
        {
            // Change the color of the ButtonManager GameObject
            GetComponent<Renderer>().material.color = Color.green;
            gameManager.SetMiniGameCompleted();
        }
    }
    public void ShuffleY<T>(List<T> list)
    {
        // Shuffle list using Fisher-Yates shuffle algorithm
        int n = list.Count;
        System.Random rng = new System.Random();

        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}