using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination;
    public float distance = 0.3f;

    public float animationDelay = 1f;

    private bool playerInRange = false;
    private Transform playerTransform;
    private Animator playerAnimator;

    public GameObject teleportTextPanel;

    // public Animator animator;

    private void Start() 
    {
        // teleportTextPanel = GameObject.FindWithTag("TeleportPanel");
    }

    private void Update()
    {

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Animator playerAnimator = playerTransform.GetComponent<Animator>();
            StartCoroutine(TeleportPlayer(playerTransform, playerAnimator));
        }
    }
    
    // private void OnTriggerEnter2D(Collider2D other) 
    // {
    //     if(other.gameObject.GetComponent<PlayerController>() != null && Input.GetKeyDown(KeyCode.E)) 
    //     {
    //         if(Vector2.Distance(other.transform.position, transform.position) > distance)
    //         {
    //             Animator playerAnimator = other.GetComponent<Animator>();

    //             StartCoroutine(TeleportPlayer(other.transform, playerAnimator));
    //         }
    //     }  
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            playerInRange = true;
            playerTransform = other.transform;
            playerAnimator = other.GetComponent<Animator>();
            teleportTextPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If player exits trigger area, prevent teleportation
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            playerInRange = false;
            playerTransform = null;
            playerAnimator = null;
            teleportTextPanel.SetActive(false);
        }
    }

    private IEnumerator TeleportPlayer(Transform player, Animator playerAnimator)
    {
        PlayerController pc = player.GetComponent<PlayerController>();

        pc.enabled = false;
        playerAnimator.SetTrigger("Teleport Start");
        

        yield return new WaitForSeconds(animationDelay);

        player.position = destination.position;

        playerAnimator.SetTrigger("Teleport End");

        yield return new WaitForSeconds(animationDelay);

        pc.enabled = true;
    }
}
