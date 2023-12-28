using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTransparency : MonoBehaviour
{
    public float Alpha;

    // Start is called before the first frame update
    void Start()
    {
        UpdateAlpha();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAlpha();
    }
    public void UpdateAlpha(float alpha = -1)
    {
        if (alpha != -1)
            Alpha = alpha;
        ChangeAlphaOfChildren(Alpha);
    }
    void ChangeAlphaOfChildren(float alphaValue)
    {
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer render in renderers)
        {
            Color color = render.material.color;
            render.material.SetColor("_BaseColor", new Color(color.r, color.g, color.b, alphaValue));
        }
    }
}
