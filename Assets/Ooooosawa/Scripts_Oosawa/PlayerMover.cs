using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float moveSpeed = 5f;
    Vector3 moveInput;

    Vector3 pos;

    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        pos = transform.position;
    }
    void FixedUpdate()
    {

        Move();
    }

    void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");

        moveInput = new Vector3(x, 0, z).normalized;

        rb.velocity = moveInput * moveSpeed;

        Rotate();
        Animation();

    }

    void Rotate()
    {
        var curPos = transform.position;

        var diff = curPos - pos;

        if (diff.magnitude > 0.01f)
        {
            rb.rotation = Quaternion.LookRotation(diff);
        }

        pos = transform.position;
    }

    void Animation()
    {
        if (rb.velocity.magnitude > 0 && !animator.GetBool("isRunning"))
            animator.SetBool("isRunning", true);
        else if (rb.velocity.magnitude <= 0 && animator.GetBool("isRunning"))
            animator.SetBool("isRunning", false);
    }
}
