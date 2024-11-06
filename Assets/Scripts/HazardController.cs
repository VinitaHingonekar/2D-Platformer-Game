using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.GetComponent<PlayerController>() != null)
        {
            // PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            // playerController.KillPlayer();
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
