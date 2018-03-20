using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

    protected Transform thisTransform;
    private Vector3 startPosition;
    private float verticalVelocity;
    private int reputation;
    private string name;
    SpriteRenderer rend;
    GameObject dialogueManager;
    DialogueManager dm;
    GameObject itemSystem;
    ItemSystem iS;
   
    // Use this for initialization
    void Start()
    {
        thisTransform = transform;
        startPosition = thisTransform.position;
       
        PrepareFade();


        dialogueManager = GameObject.Find("DialogueManager");
        dm = dialogueManager.GetComponent<DialogueManager>();

        itemSystem = GameObject.Find("ItemSystem");
        iS = itemSystem.GetComponent<ItemSystem>();

        StartCoroutine(Animator());
    }

    private void Update()
    {
       // print(dm.dialogended);
        startFadingOut();
        dm.dialogended = false;
    }
    #region Animation 
    public void PrepareFade()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
        // startFading();

    }
    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void startFading()
    {
        StartCoroutine(FadeIn());
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

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

    }
    public void startFadingOut()
    {
        if (dm.dialogended && iS.itemSold)
        {

            StartCoroutine(FadeOut());
        }

    }

    IEnumerator Animator()
    {
        startFading();
        // startFadingOut();

        yield return null;
    }
    #endregion


}


