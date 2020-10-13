using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth;
    private int _currentHealth;

    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2d;
    float _timer;
    int _direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        _timer = changeTime;
        _currentHealth = maxHealth;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            _direction = -_direction;
            _timer = changeTime;
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if(vertical)
        {
            position.y = position.y + Time.deltaTime * speed;
        }
        else
            position.x = position.x + Time.deltaTime * speed;

        rigidbody2d.MovePosition(position);
    }

    //We use OnCollisioneEnter for when there is a collision between the two gameObjects/characters
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SwordCatController player = collision.gameObject.GetComponent<SwordCatController>();
        if (player != null)
            player.ChangeHealth(-1);
    }
}
