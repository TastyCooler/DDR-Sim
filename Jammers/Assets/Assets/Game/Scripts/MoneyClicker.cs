using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyClicker : MonoBehaviour {

    public int score = 0;
    public Transform text;
    public AudioClip knock;
    int counter = 0;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        //print(score);
        text.GetComponent<TextMesh>().text = score.ToString();
        if (score == 50)
        {
            counter = counter + 1;
            if (counter == 1)
            {
                AudioSource.PlayClipAtPoint(knock, transform.position);
            }
            
        }
    }
}
