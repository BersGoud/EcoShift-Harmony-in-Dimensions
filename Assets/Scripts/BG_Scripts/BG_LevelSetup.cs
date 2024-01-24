using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Leve : MonoBehaviour
{
    public CountdownManager countdown;
    // Start is called before the first frame update
    void Start()
    {
      //countdown = gameObject.GetComponent<CountdownManager>();
        DimensionalShift dimensionalShift = gameObject.GetComponent<DimensionalShift>();
        dimensionalShift.isDimensionalShiftEnabled = true;
        dimensionalShift.OnCameraChanged += DimensionalShift_OnCameraChanged;
    }

    private void DimensionalShift_OnCameraChanged(bool cameraIs3D)
    {
        GameObject[] remove = GameObject.FindGameObjectsWithTag("RemoveIn2D");
        if (!cameraIs3D)
        {
            foreach (GameObject obj in remove)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject obj in remove)
            {
                obj.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartCounter()
    {
        countdown.StartCountdown();
    }
}
