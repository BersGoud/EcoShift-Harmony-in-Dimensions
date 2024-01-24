using Assets.Scripts.UI;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopUI : CanvasManagerBase
{
    public BooksTeacherInteraction teacherInteraction;
    public LaptopInteraction LaptopInteraction;
    public override void Hide(bool enableMovement = true)
    {
        base.Hide(enableMovement);
        LaptopInteraction.AllowInteraction = false;
    }
    public void RecyledClicked()
    {
        Hide();
        if (teacherInteraction.TotalBooks <= 0)
            teacherInteraction.EnableBookOnBottom(true);
    }

    public void NormalClicked()
    {
        Hide();
        if (teacherInteraction.TotalBooks <= 0)
            teacherInteraction.EnableBookOnBottom(false);
    }
}
