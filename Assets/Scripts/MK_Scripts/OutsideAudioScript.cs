using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideAudioScript : MonoBehaviour
{
    /// <summary>
    /// Script to play the wind audio when the player goes outside
    /// </summary>
    private AudioSource _source;


    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player (you can customize the player tag or layer)
        if (other.CompareTag("Player"))
        {
            _source.Play();
        }
    }
}
