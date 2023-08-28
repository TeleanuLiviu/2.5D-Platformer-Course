using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform PosA, PosB;
    [SerializeField]
    public float _speed = 5.0f;
    public bool switchPos = true;
    void FixedUpdate()
    {

        if (switchPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, PosB.position, Time.deltaTime * _speed);
        }

        else if(!switchPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, PosA.position, Time.deltaTime * _speed);
        }

        if (transform.position == PosA.position)
        {
            switchPos = true;
        }
        
        else if (transform.position == PosB.position)
        {
            switchPos = false;
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}

