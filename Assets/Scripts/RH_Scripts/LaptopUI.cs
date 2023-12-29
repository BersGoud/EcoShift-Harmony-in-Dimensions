using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopUI : MonoBehaviour
{
    public BooksTeacherInteraction teacherInteraction;
    public void RecyledClicked()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        if (teacherInteraction.TotalBooks <= 0)
            teacherInteraction.EnableBookOnBottom(true);
    }

    public void NormalClicked()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        if (teacherInteraction.TotalBooks <= 0)
            teacherInteraction.EnableBookOnBottom(false);
    }
}
