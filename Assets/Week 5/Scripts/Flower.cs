using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private float nectarProductionRate = 5;
    private float counter = 0;

    private bool hasNectar;

    [SerializeField] SpriteRenderer flowerColor;

    public bool NectarAvailable()
    {
        if (hasNectar == true);
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasNectar == false)
        {
            flowerColor.color = Color.gray;
            counter++;
            if (counter == nectarProductionRate)
            {
                hasNectar = true;
                counter = 0;
                flowerColor.color = Color.white;
            }
        }     
    }
}
