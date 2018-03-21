using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

    protected Transform thisTransform;
    private Vector3 startPosition;
    private float verticalVelocity;
    public int reputation;
    private string name;
   public SpriteRenderer rend;
    GameObject dialogueManager;
    public DialogueManager dm;

    public bool active;
    
   
    // Use this for initialization
    void Start()
    {
        thisTransform = transform;
        startPosition = thisTransform.position;
       
        PrepareFade();
        active = true;

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

    public virtual void  startFading()
    {
        StartCoroutine(FadeIn());
    }


    IEnumerator FadeOut()
    {
        
        int counter = 0;
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            counter += 1;
            if (counter == 21)
            {

                dm.finish = true;
                
            }
            
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


