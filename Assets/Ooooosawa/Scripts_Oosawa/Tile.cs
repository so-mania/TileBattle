using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
        if (this.myColor != color)
        {
            ChangeMyColor(color);
        }
    }

    void ChangeMyColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
        this.myColor = color;

        if (this.myColor == Color.red)
            transform.parent.tag = "Red";
        else if (this.myColor == Color.blue)
            transform.parent.tag = "Blue";
    }
}
