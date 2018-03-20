using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

    protected Transform thisTransform;
    private Vector3 startPosition;
    private float verticalVelocity;
    public int reputation;
    private string name;
    SpriteRenderer rend;
    GameObject dialogueManager;
    public DialogueManager dm;
    
   
    // Use this for initialization
    void Start()
    {
        thisTransform = transform;
        startPosition = thisTransform.position;
       
        PrepareFade();


        dialogueManager = GameObject.Find("DialogueManager");
        dm = dialogueManager.GetComponent<DialogueManager>();

       

        StartCoroutine(Animator());
    }

    private void Update()
    {
        print(dm.dialogended);
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
        if (dm.dialogended)
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


