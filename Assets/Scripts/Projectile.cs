using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float _speed = 8f;
    public Rigidbody2D rigidbody2d;

    float _TimeToLive = 2f;

    // Start is called before the first frame update
    //Awake is called immediately when the object is created, or instantiate
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = transform.right * _speed;
        Destroy(gameObject, _TimeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -360) * Time.deltaTime);

        //if (transform.position.magnitude > 100.0f)            
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && Grid.FindObjectOfType<CompositeCollider2D>())
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyController>().Damage();
            Debug.Log("Projectile Collision with " + collision.gameObject);            
        }

      /*EnemyController e = collision.gameObject.GetComponent<EnemyController>();
      if (e != null)
          e.Fix();
          */        
    }
}
