using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpikeLauncher : MonoBehaviour
{
    private static SpikeLauncher instance;

    [SerializeField] GameObject launcher;
    [SerializeField] GameObject spikePrefab;
    bool stop = false;

    private void Awake()
    {
        
        Week6.PlayerController2D.GameOver.AddListener(OnGameOver);
        Week6.PlayerController2D.ResetGame.AddListener(OnReset);
        MazeEndTrigger.YouWin.AddListener(OnWin);
        DontDestroyOnLoad(gameObject);
        InvokeRepeating("FireSpike", 3f, 2f);
        
    }

    void OnGameOver()
    {
        stop = true;
    }

    void OnWin()
    {
        stop = true;
    }

    void OnReset()
    {
        stop = false;
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        
    }*/

    private void FireSpike()
    {
        if (stop == false)
        {
            GameObject newSpike = Instantiate(spikePrefab);
            newSpike.transform.position.Set(launcher.transform.position.x, launcher.transform.position.y, 0);
        }
    }
}
