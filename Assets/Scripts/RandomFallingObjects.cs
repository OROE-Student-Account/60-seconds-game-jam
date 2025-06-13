using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFallingObjects : MonoBehaviour
{
    public GameObject prefab;
    public int rate; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount%rate==0)
        {
            GameObject newObject = Instantiate(prefab, new Vector3(Random.Range(-4,5),5, Random.Range(-4, 5)), new Quaternion(0,0,0,1));
        }
        
    }
}
