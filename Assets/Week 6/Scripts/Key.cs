using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject KeySprite;
    public bool hasKey = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        KeySprite.SetActive(false);
        hasKey = true;
    }
}
