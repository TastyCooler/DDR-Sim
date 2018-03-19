using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    SpriteRenderer sprite;

    public Sprite originSprite;
    public Sprite targetSprite;
	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        transform.localScale = new Vector3(0.30f, 0.30f, 0.30f);
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(0.26f, 0.26f, 0.26f);
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
