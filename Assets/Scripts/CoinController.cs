using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if( other.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.Play(Sounds.KeyPickup);
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.CoinPickup();
            Destroy(gameObject);
        }    
    }
}
