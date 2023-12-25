using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseParticleEffect : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    public Color particleColor = Color.red;

    void Update()
    {
        // Get mouse position in the world
        Vector3 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Position.z = 1;

        // Move the particle system to the mouse position
        particleSystem.transform.position = Position;

        // If left mouse button is pressed, play the particle system
        if (Input.GetMouseButton(0))
        {
            if (!particleSystem.isPlaying)
            {
                // Set particle system color
                var mainModule = particleSystem.main;
                mainModule.startColor = particleColor;

                particleSystem.Play();
                Debug.Log("Mouse");
            }
        }
        else
        {
            // Stop the particle system if the mouse button is released
            particleSystem.Stop();
        }
    }
}