using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public static int keysCollected = 0;
    private bool isPickedUp = false;

    // public KeyManager keyManager;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;
            
            GameObject keyObject = GameObject.Find("KeyManager");
            KeyManager keyManager = keyObject.GetComponent<KeyManager>();

            keyManager.KeyCollected();
            keyManager.UpdateKeys();

            // Debug.Log(keysCollected);
            // Debug.Log("hitting " + other);

            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            SoundManager.Instance.Play(Sounds.KeyPickup);
            playerController.KeyPickup();
            Destroy(gameObject);

        }
    }
}
