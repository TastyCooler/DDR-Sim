using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    private bool switchStates = true; // dialog
    private bool toggleOn = true;
    private float asdf = 10;
    private IEnumerator coroutine;
	
	// Update is called once per frame
	void Update () {
        if (switchStates)
        {
            //if (toggleOn)
            //{
                coroutine = startSomething(asdf);
                StartCoroutine(coroutine);
                //toggleOn = false;
                switchStates = false;
            //}
        }
    }

    void Start()
    {
        Debug.Log("Start");
    }

    IEnumerator startSomething(float asdf)
    {
        yield return asdf;
        Debug.LogFormat("asdf {0}", asdf);
    }
}
