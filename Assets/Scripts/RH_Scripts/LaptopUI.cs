using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopUI : MonoBehaviour
{
    public ThirdPersonController Player;
    public BooksTeacherInteraction teacherInteraction;
    private Canvas canvas;
    private void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
    }
    public void EnableUI()
    {
        canvas.enabled = true;
        Player.CameraMovementEnabled = false;
    }
    public void DisableUI()
    {
        canvas.enabled = false;
        Player.CameraMovementEnabled = true;
    }
    public void RecyledClicked()
    {
        DisableUI();
        if (teacherInteraction.TotalBooks <= 0)
            teacherInteraction.EnableBookOnBottom(true);
    }

    public void NormalClicked()
    {
        DisableUI();
        if (teacherInteraction.TotalBooks <= 0)
            teacherInteraction.EnableBookOnBottom(false);
    }
}
