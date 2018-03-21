using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : ButtonScript
{

    private bool toggledRed;

    public bool ToggledRed
    {
        get { return toggledRed; }
    }

    public override void OnMouseDown()
    {
        sprite.sprite = targetSprite;
        mC.score--;
        AudioSource.PlayClipAtPoint(press, transform.position);
        toggledRed = true;
    }

    public override void OnMouseUp()
    {
        sprite.sprite = originSprite;
        toggledRed = false;
    }
}
