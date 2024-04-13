using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject KeySprite;
    public bool hasKey = false;

    private void OnTriggerEnter2D(Collider2D key)
    {
        Week6.PlayerController2D.ResetGame.AddListener(Reset);
        KeySprite.SetActive(false);
        hasKey = true;
    }

    void Reset()
    {
        KeySprite.SetActive(true);
        hasKey = false;
    }
}
