using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject DoorSprite;
    [SerializeField] Key doorKey;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(doorKey.hasKey == true)
        {
            DoorSprite.SetActive(false);
        }
    }
}
