using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 0.25f;

    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    /*void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }*/

    private void Start()
    {
        animator.SetFloat("Y", -1);
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0 || vertical != 0) 
        {
            animator.SetFloat("X", horizontal);
            animator.SetFloat("Y", vertical);

            if (horizontal == 1)
            {
                gameObject.transform.localScale = new Vector3(2.41252f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
            else if (horizontal == -1)
            {
                gameObject.transform.localScale = new Vector3(-2.41252f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        transform.Translate(horizontal * speed, vertical * speed, 0f);
    }
}
