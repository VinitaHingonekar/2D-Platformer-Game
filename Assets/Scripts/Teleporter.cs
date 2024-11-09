using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination;
    public float distance = 0.3f;

    public float animationDelay = 1f;

    // public Animator animator;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            if(Vector2.Distance(other.transform.position, transform.position) > distance)
            {
                Animator playerAnimator = other.GetComponent<Animator>();

                // other.transform.position = destination.position;
                StartCoroutine(TeleportPlayer(other.transform, playerAnimator));
            }
        }  
    }

    private IEnumerator TeleportPlayer(Transform player, Animator playerAnimator)
    {
        PlayerController pc = player.GetComponent<PlayerController>();
        // TeleporterAnimation();

        pc.enabled = false;
        playerAnimator.SetTrigger("Teleport Start");
        

        yield return new WaitForSeconds(animationDelay);

        player.position = destination.position;

        playerAnimator.SetTrigger("Teleport End");

        yield return new WaitForSeconds(animationDelay);

        pc.enabled = true;
    }
}
