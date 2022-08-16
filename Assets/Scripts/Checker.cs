using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    Renderer renderer;

    public CheckerState checkerState;
    public int Num;
    public bool TheKing = false;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        SetColor();
    }

    private void SetColor()
    {
        switch (checkerState)
        {
            case CheckerState.black:
                renderer.material.color = Color.black;
                break;
            case CheckerState.white:
                renderer.material.color = Color.white;
                break;
        }
    }
}
