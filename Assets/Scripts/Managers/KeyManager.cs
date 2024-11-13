using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public Image[] keys;
    public int keysCollected = 0;

    private Animator[] keyAnimators;

    private void Start() 
    {
        keyAnimators = new Animator[keys.Length];
        for (int i = 0; i < keys.Length; i++)
        {
            keyAnimators[i] = keys[i].GetComponent<Animator>();
        }
    }

    public void UpdateKeys()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (i < keysCollected)
            {
                keyAnimators[i].SetTrigger("KeyPickedUp");
            }
        }   
    }
    
    public void KeyCollected()
    {
        keysCollected++;
    }
}
