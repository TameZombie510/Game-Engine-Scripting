using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    public int score;
    public string name;
    public float balance;

    [ContextMenu("Load")]

    public void LoadDataTest()
    {
        score = PlayerPrefs.GetInt("score", 1000);
        name = PlayerPrefs.GetString("username");
        balance = PlayerPrefs.GetFloat("balance");
    }
}
