using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
        /*It's enough to write OnTrigger and automatically the compiler will compile the function
         We use OnTriggerStay for when the character enter and stay in the damage zone to trigger the function
         */
    {
        SwordCatController controller = collision.GetComponent<SwordCatController>();
        if (controller != null)
            controller.ChangeHealth(-1);
    }
}
