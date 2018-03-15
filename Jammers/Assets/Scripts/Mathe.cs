using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mathe : MonoBehaviour {

    Kunden f;

	// Use this for initialization
	void Start () {
        f = GetComponent<Kunden>();
	}
	
	// Update is called once per frame
	void Update () {

        Test();
        
	}

    void Test()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            f.KundeGenerieren();
            //Debug.LogFormat("Kunde {0} ist gekommen, *rep*={1}, Mark toleranz {2}", f.name, f.reputation, f.toleranz);
        }
    }
}
