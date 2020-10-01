using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCatController : MonoBehaviour 
{
    // Class means defining a new component, in this case SwordCatController
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position; //declared a var of type Vector2 called position
        position.x = position.x + 0.1f;//floating point, float type
        transform.position = position;
    }
}
