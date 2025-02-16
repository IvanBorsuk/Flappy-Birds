using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;
    private Rigidbody2D rb;
    private Animator anim;
    [NonSerialized] public bool isDead;

    private void Awake()
    {
        player = this;
    }

    void Start()
    {
        InitPlayer();
    }

 
    void Update()
    {
        MovePlayer();
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, LevelControler.singeltone.jumpPower);
        }
       
    }

    private void InitPlayer()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isDead = false;
        
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector2(LevelControler.singeltone.speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pipe")
        {
            Debug.Log(collision.collider.tag);
            isDead = true;
            anim.SetBool("isDead", isDead);
            StopAllCoroutines();

            Time.timeScale = 0;
            
        }
    }

}
