using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    private float honeyProductionRate;
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
            Instantiate(beePreFab);
           
            //Bee.Init(hive);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveNectar()
    {

    }
}
