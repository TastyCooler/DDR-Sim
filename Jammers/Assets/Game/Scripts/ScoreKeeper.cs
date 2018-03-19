using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    public int Maltereputation = 50;
    public int Matthiasreputation = 30;
    bool clicked = false;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DeclinePerson()
    {
       
        if (GameObject.Find("Matthias") && !clicked)
        {
            Matthiasreputation = Matthiasreputation - 2;
            Debug.Log("found Matthias");
            Debug.Log(Matthiasreputation);
            
            clicked = true;
            Debug.Log(clicked);
        }
        if (GameObject.Find("Malte") && !clicked)
        {
            Matthiasreputation = Maltereputation - 2;
            Debug.Log("found Malte");
            Debug.Log(Maltereputation);
            clicked = true;
        }
    }

    public void AcceptPerson()
    {
        
        if (GameObject.Find("Matthias") && !clicked)
        {
            Matthiasreputation = Matthiasreputation + 2;
            Debug.Log("found Matthias");
            Debug.Log(Matthiasreputation);
            
            clicked = true;
            Debug.Log(clicked);
        }
        if (GameObject.Find("Malte") && !clicked)
        {
            Maltereputation = Maltereputation + 2;
            Debug.Log("found Malte");
            Debug.Log(Maltereputation);
            clicked = true;
        }
    }
}
