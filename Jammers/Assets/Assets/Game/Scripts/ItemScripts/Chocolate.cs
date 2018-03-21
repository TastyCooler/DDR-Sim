using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocolate : ObjectPhysics {

    public override void OnMouseEnter()
    {
        //change the scale of the object to make it clear it's been selected
        this.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }

    public override void OnMouseExit()
    {
        //reset the scale to default when the object is no longer selected
        this.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }
}
