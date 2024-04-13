using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject DoorSprite;
    [SerializeField] Key doorKey;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Week6.PlayerController2D.ResetGame.AddListener(Reset);
        if (doorKey.hasKey == true)
        {
            DoorSprite.SetActive(false);
        }
    }

    void Reset()
    {
        DoorSprite.SetActive(true);
    }
}
