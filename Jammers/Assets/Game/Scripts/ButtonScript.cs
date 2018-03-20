using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    SpriteRenderer sprite;

    public Sprite originSprite;
    public Sprite targetSprite;
    public Sprite hoverSprite;
	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        transform.localScale = new Vector3(0.42f, 0.42f, 0.42f);
        sprite.sprite = hoverSprite;
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(0.37f, 0.37f, 0.37f);
        sprite.sprite = originSprite;
    }

    private void OnMouseDown()
    {
        sprite.sprite = targetSprite;
    }

    private void OnMouseUp()
    {
        sprite.sprite = originSprite;
    }

}
