using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : Creature {

    public override void Talk()
    {
        Debug.Log("Bird says dave");
    }

    protected override void Move()
    {
        base.Move();
        thisTransform.position += Vector3.up * Mathf.Sin(Time.deltaTime);
    }

    protected override void Jump()
    {
       
    }
}
