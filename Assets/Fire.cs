﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GameManager.instance.Score();
            animator.SetTrigger("fire");
        }
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.GameOver();
            collision.gameObject.GetComponent<Player>().isDie = true;
            animator.SetTrigger("fire");
        }

    }
}
