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

        DialogueSystem.DisplayDialogue(new string[] { "TEST" });

        StartCoroutine(Intro());
    }

    private IEnumerator Intro()
    {
        DialogueSystem.clickToSkip = false;

        //Don't use this as an example, the dialogue system is to be rewritten.

        /*DialogueSystem.DisplayDialogue(new string[] { "[You hear the sound of a schoolbell.]"});

        DialogueSystem.DisplayNext(1);
        yield return new WaitForSeconds(0.5F);

        DialogueSystem.DisplayDialogue(new string[] { "Hm..? A key?", "How would I be able to reach it?" });
        DialogueSystem.DisplayNext(1);
        DialogueSystem.DisplayNext(1);
        yield return new WaitForSeconds(0.5F);

        DialogueSystem.DisplayDialogue(new string[] { "Books?" });
        DialogueSystem.DisplayNext(1);
        yield return new WaitForSeconds(0.5F);

        //Center text.
        DialogueSystem.DisplayDialogue(new string[] { "(CENTERED) Quick! Deliver the books to the children in time!" });
        DialogueSystem.DisplayNext();*/
        yield return null;

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
