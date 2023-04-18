using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private float speed = 7;
    [SerializeField] private Transform waist;
    private Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction = input.normalized;

        if(direction.magnitude > 0)
            animator.Play("Walking");
        else
            animator.Play("Idle");

        if(input.x != 0)
        {
            waist.localScale = new Vector3(input.x < 0 ? -1 : 1, 1,1);
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}
