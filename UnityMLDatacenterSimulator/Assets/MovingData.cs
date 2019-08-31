using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingData : MonoBehaviour
{

    public GameObject Datablock;
    public float speed;
    float position;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = Datablock.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(position < 200)
        {
            position += speed;
        }
        else
        {
            position = 0;
        }



        Vector3 temp = new Vector3(startPosition.x + position, startPosition.y, startPosition.z);
        Datablock.transform.position = temp;
    }
}
