using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : RegisterBase {
    #region Public Fields

    public SpriteRenderer sprite;
    public Sprite originSprite;
    public Sprite targetSprite;
    public Sprite hoverSprite;

    public MoneyClicker mC;
    public GameObject MoneyClicker;

    public AudioClip press;

    #endregion

    #region Private Fields 

    private bool toggledGreen;

    #endregion

    #region Public Class Functions

    public bool ToggledGreen {
        get { return toggledGreen; }
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

    #endregion

    #region Unity Functions

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        MoneyClicker = GameObject.Find("Money");
        mC = MoneyClicker.GetComponent<MoneyClicker>();
    }

    #endregion

    #region Private Class Functions

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

    #endregion
}
