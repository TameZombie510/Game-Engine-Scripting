using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavaData : MonoBehaviour
{
    public int score;
    public string name;
    public float balance;

    [ContextMenu("Save")]

    public void SaveDataTest()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetString("Max", name);
        PlayerPrefs.SetFloat("balance", balance);
    }
}
