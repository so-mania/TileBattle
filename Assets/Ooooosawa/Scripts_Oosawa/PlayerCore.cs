using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    GameManager manager;

    PlayerMover mover;
    CapsuleCollider myCol;

    public Color myColor { get; private set; }

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        mover = GetComponent<PlayerMover>();
        myCol = GetComponent<CapsuleCollider>();
    }

    void Start()
    {
        switch (gameObject.name)
        {
            case "Player1(Clone)":
                manager.readyPlayer1 = true;
                myColor = Color.red;
                break;
            case "Player2(Clone)":
                manager.readyPlayer2 = true;
                myColor = Color.blue;
                break;
        }
    }

    void Update()
    {
        ComponentSwitch(manager.isPlaying);
    }

    void ComponentSwitch(bool value)
    {
        mover.enabled = value;
        myCol.enabled = value;
    }
}
