using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeLauncher : MonoBehaviour
{
    private static SpikeLauncher instance;

    [SerializeField] GameObject launcher;
    [SerializeField] GameObject spikePrefab;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        InvokeRepeating("FireSpike", 3f, 2f);
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        
    }*/

    private void FireSpike()
    {
        GameObject newSpike = Instantiate(spikePrefab);
        newSpike.transform.position.Set(launcher.transform.position.x, launcher.transform.position.y, 0);
    }
}
