using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite defaultSprite;
    public Sprite changedSprite;

    public GameObject text;

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {   
            text.SetActive(true);
            spriteRenderer.sprite = changedSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {   
            text.SetActive(false);
            spriteRenderer.sprite = defaultSprite;
        }
    }
}
