using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCatController : MonoBehaviour 
{
    Rigidbody2D rigidbody2d;
    float horizontal, vertical;

    // Class means defining a new component, in this case SwordCatController
    void Start()
    {
        /* the two lines below is to demonstrate how to control the speed of your game so that it’s the same on any machine.
            Your character now runs at the same speed, regardless of the number of frames rendered by our game. 
            It’s now “frame independent”.
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 10;*/

        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*because we added Rigidbody, we can create the variables at the start, thus we won't need them here
        float horizontal = Input.GetAxis("Horizontal"); //we call GetAxis inside Input, which is a function in Unity
        float vertical = Input.GetAxis("Vertical");
        */
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        /*also, we move the lines below to the FixedUpdate function
        Vector2 position = transform.position; //declared a var of type Vector2 called position
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;//floating point, float type
        position.y = position.y + 3.0f * vertical * Time.deltaTime; //Character moves 3 units per second
        transform.position = position;    
        */
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }
}
