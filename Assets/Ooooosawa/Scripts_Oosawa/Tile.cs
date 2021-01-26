using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Color myColor;

    private void Awake()
    {
        myColor = GetComponent<Renderer>().material.color;
    }

    private void OnTriggerEnter(Collider col)
    {
        var color = col.GetComponent<PlayerCore>().myColor;
        if (myColor != color)
        {
            ChangeMyColor(color);
        }
    }

    void ChangeMyColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
        myColor = color;
    }
}
