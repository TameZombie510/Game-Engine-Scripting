using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject CoinSprite;
    public bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Week6.PlayerController2D.ResetGame.AddListener(Reset);
        CoinSprite.SetActive(false);
        collected = true;
    }

    void Reset()
    {
        CoinSprite.SetActive(true);
        collected = false;
    }

}
