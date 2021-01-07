using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    void Start()
    {
        
    }

    void Update()
    {
        float x;
        x = Input.GetAxis("Horizontal");
        float z;
        z = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(x, 0, z) * speed * Time.deltaTime);
    }
}
