using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Object that entered the trigeer: " + collision);
        SwordCatController controller = collision.GetComponent<SwordCatController>();
        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
            }
            else 
                MaxHealth();
        }
    }
    void MaxHealth()
    {
        Debug.Log("You have max health");
    }
}
