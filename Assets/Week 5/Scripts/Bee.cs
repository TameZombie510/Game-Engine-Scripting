using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bee : MonoBehaviour
{
    private Hive Beehive = new();



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(Hive hive)
    {
        hive = Beehive;
    }

    private void CheckAnyFlower()
    {    
        Flower[] flower = FindObjectsByType<Flower>(FindObjectsSortMode, 0);
        int RandomFlower = Random.Range(0, flower.Length);
        

        transform.DOMove(flower[RandomFlower].transform.position, 1f).OnComplete(() =>
        {
            //Take nectar from flower
            flower[RandomFlower].NectarAvailable();
            //If flower returned nectar then go back to the hive and give hive nectar
            if (true)
            {
                transform.DOMove(Beehive.transform.position, 1f).OnComplete(() =>
                {
                    Beehive.GiveNectar();
                }).SetEase(Ease.Linear);
            }
            //If flower did not return nectar then go check another flower
            if (false)
            {
                
            }
        }).SetEase(Ease.Linear);
    }
}
