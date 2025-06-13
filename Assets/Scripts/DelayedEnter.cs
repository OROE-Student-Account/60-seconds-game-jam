using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedEnter : MonoBehaviour
{
    public GameObject entryObject;
    public int delay;
    public bool enter;
    private int count;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count += 1;
        if (count>delay)
        {
            if (enter)
            {
                entryObject.SetActive(true);
            }
            else
            {
                entryObject.SetActive(false);
            }
            
        }
    }
}
