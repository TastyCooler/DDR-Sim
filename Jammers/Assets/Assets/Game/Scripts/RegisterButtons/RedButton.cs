using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : ButtonScript {

    public override void OnMouseDown()
    {
        sprite.sprite = targetSprite;
        mC.score--;
    }
}
