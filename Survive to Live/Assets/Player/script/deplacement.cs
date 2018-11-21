using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    public float speed = 0.035f;

    private Vector2 input; //vector input
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mouvement();
        MouvementAnimation(input);
    }

    //player
    void mouvement()
    {
        input = Vector2.zero;
        input.x = Input.GetAxisRaw("Horizontal") * speed;
        input.y = Input.GetAxisRaw("Vertical") * speed;

        transform.Translate(input);
    }

    //Update sprite animation
    void MouvementAnimation(Vector2 input)
    {
        if (input.x < 0 && input.y == 0)
            animator.SetTrigger("player left");

        if (input.x > 0 && input.y == 0)
            animator.SetTrigger("player right");

        if (input.x == 0 && input.y < 0)
            animator.SetTrigger("player down");

        if (input.x == 0 && input.y > 0)
            animator.SetTrigger("player up");

        if (input.x == 0 && input.y == 0)
            animator.SetTrigger("player idle");
    }


}