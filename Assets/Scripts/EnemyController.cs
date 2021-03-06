﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2d;
    float _timer;
    int _direction = 1;

    Animator animator;

    bool broken = true;

    public ParticleSystem smokeEffect;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        _timer = changeTime;
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!broken)
        {
            return;
        }
            
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            _direction = -_direction;
            _timer = changeTime;
        }
    }

    private void FixedUpdate()
    {
        if (broken != true)
        {
            return;
        }            

        Vector2 position = rigidbody2d.position;

        if(vertical)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", _direction);
            position.y = position.y + Time.deltaTime * speed;
        }
        else
        {
            animator.SetFloat("Move X", _direction);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + Time.deltaTime * speed;
        }

        rigidbody2d.MovePosition(position);        
    }

    //We use OnCollisioneEnter for when there is a collision between the two gameObjects/characters
    private void OnCollisionStay2D(Collision2D collision)
    {
        SwordCatController controller = collision.gameObject.GetComponent<SwordCatController>();

        if (controller != null)
            controller.ChangeHealth(-1);
    }

    public void Damage()
    {
        currentHealth -= 1;
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    public void Fix()
    {
        broken = false;
        rigidbody2d.simulated = false;
    }
}
