using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    private float honeyProductionRate = 5;
    private float startingNumberOfBees;
    private int nectarAmount;
    private int honeyAmount;
    private float timer;
    

    [SerializeField] GameObject beePreFab;
    

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < startingNumberOfBees; i++)
        {
            Instantiate(beePreFab, Bee.Init(Hive());
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (nectarAmount > 0)
        {

            timer = honeyProductionRate;
            timer--;
            if (timer == 0)
            {
                nectarAmount -= 1;
                honeyAmount += 1;
            }


        }
    }

    public void GiveNectar()
    {
        nectarAmount += 5;
        if (timer == 0) 
        {
            timer = honeyProductionRate;
        }
    }
}
