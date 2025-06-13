using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float xMover;
    public float yMover;
    public float zMover;
    public int timeFrame;
    public int delay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.frameCount+delay)%timeFrame*2<timeFrame)
        {
            transform.position = new Vector3(transform.position.x + xMover, transform.position.y + yMover, transform.position.z + zMover);
        }
        else 
        {
            transform.position = new Vector3(transform.position.x - xMover, transform.position.y - yMover, transform.position.z - zMover);
        }
        
    }
}
