using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RH_LevelSetup : MonoBehaviour
{
    // Start is called before the first frame update

    public BoxCollider Key;
    public DialogueSystem DialogueSystem;

    void Start()
    {
        DimensionalShift.isDimensionalShiftEnabled = true;
        DimensionalShift.OnCameraChanged += DimensionalShift_OnCameraChanged;


        DialogueSystem.DisplayDialogue(new string[] { "Testing", "Testing!" });
    }

    private void DimensionalShift_OnCameraChanged(bool cameraIs3D)
    {
        GameObject[] remove = GameObject.FindGameObjectsWithTag("RemoveIn2D");
        if (!cameraIs3D)
        {
            foreach (GameObject obj in remove)
            {
                obj.GetComponent<Renderer>().enabled = false;
            }
            Key.enabled = true;
        } else
        {
            foreach (GameObject obj in remove)
            {
                obj.GetComponent<Renderer>().enabled = true;
            }
            Key.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
