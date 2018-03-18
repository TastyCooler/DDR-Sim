using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matthias : Human {

    public override void Talk()
    {
        Debug.Log("Matthias says hi!");
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
