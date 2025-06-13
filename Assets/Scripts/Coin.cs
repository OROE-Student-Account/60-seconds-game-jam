using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private int count;
    public GameObject secondCoin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += 1;
        if (count>100)
        {
            transform.gameObject.SetActive(false);
        }

        if (Time.frameCount%30>15)
        {
            secondCoin.SetActive(true);
        }
        else
        {
            secondCoin.SetActive(false);
        }
    }
}
