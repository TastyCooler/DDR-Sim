using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

    protected Transform thisTransform;
    private Vector3 startPosition;
    private float verticalVelocity;
    private int reputation;
    private string name;

    // Use this for initialization
    void Start()
    {
        thisTransform = transform;
        startPosition = thisTransform.position;
    }

    private void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        Vector3 pos = startPosition + Vector3.right;
        verticalVelocity -= 14 * Time.deltaTime;

        if (verticalVelocity < 0)
        {
            verticalVelocity = 0;

            pos.y = verticalVelocity + startPosition.y;
            thisTransform.position = pos;
        }
    }

    public virtual void Talk() // instead of virtual use abstract, if everyone talks unique; the class has to be abstract as well!!! And this method has to be overrided!
    {
        Debug.Log("Creatue says : Good Times");
    }

    protected virtual void Jump()
    {
        verticalVelocity = 2.0f;
    }
}


