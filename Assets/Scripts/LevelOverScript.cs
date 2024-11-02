using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Next Level");
        }
    }
}
