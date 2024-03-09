using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bee : MonoBehaviour
{
    [SerializeField]private Hive Beehive;

    public static void Init(Hive hive)
    {
        //Beehive = hive;
    }

    private void CheckAnyFlower()
    {
        Flower[] flower = { };
            //FindObjectsByType<Flower>(FindObjectsSortMode.None);
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
                CheckAnyFlower();
            }
        }).SetEase(Ease.Linear);
    }
}
