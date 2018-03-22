using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : RegisterBase {

    public SpriteRenderer sprite;

    public Sprite originSprite;
    public Sprite targetSprite;
    public Sprite hoverSprite;
    public MoneyClicker mC;
    public GameObject MoneyClicker;

    public AudioClip press;

    private bool toggledGreen;

    public bool ToggledGreen
    {
        get { return toggledGreen; }
    }

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        MoneyClicker = GameObject.Find("Money");
        mC = MoneyClicker.GetComponent<MoneyClicker>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(0.42f, 0.42f, 0.42f);
        sprite.sprite = hoverSprite;

    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(0.37f, 0.37f, 0.37f);
        sprite.sprite = originSprite;
    }

    public virtual void OnMouseDown()
    {
        sprite.sprite = targetSprite;
        mC.score++;
        AudioSource.PlayClipAtPoint(press, transform.position);

        /////////////////////////////////////
        // let the registerBase shake here //
        /////////////////////////////////////
        toggledGreen = true;
    }

    public virtual void OnMouseUp()
    {
        sprite.sprite = originSprite;
        toggledGreen = false;
    }

}
