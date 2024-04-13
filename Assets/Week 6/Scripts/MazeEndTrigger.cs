using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MazeEndTrigger : MonoBehaviour
{
    [SerializeField] GameObject YouWinPopup;
    public static UnityEvent YouWin = new UnityEvent();
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        YouWinPopup.SetActive(true);
        YouWin.Invoke();
        Week6.PlayerController2D.ResetGame.AddListener(Reset);
    }

    void Reset()
    {
        YouWinPopup.SetActive(false);
    }
}
