using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            SoundManager.Instance.Play(Sounds.KeyPickup);
            playerController.KeyPickup();
            Destroy(gameObject);
        }
    }
}
