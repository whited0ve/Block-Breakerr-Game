﻿using UnityEngine;

public class ColorTransition : MonoBehaviour
{
    public Material material;
    public Color[] colors;
    private int currentColorIndex = 0;
    private int targetColorIndex = 1;
    private float targetPoint = 0f;
    public float time;

    void Update()
    {
        Transition();
    }

    void Transition()
    {
        targetPoint += Time.deltaTime / time;
        material.color = Color.Lerp(colors[currentColorIndex], colors[targetColorIndex], targetPoint);
        if (targetPoint >= 1f)
        {
            targetPoint = 0f;
            currentColorIndex = targetColorIndex;
            targetColorIndex++;
            if (targetColorIndex == colors.Length)
                targetColorIndex = 0;
        }
    }
}
