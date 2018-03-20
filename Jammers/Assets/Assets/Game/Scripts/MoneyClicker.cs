using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyClicker : MonoBehaviour {

    public int score;
    public Transform text;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        print(score);
        text.GetComponent<TextMesh>().text = score.ToString();

    }
}
