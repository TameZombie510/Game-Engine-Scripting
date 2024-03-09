using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeEndTrigger : MonoBehaviour
{
    [SerializeField] GameObject YouWinLabel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        YouWinLabel.SetActive(true);
    }
}
