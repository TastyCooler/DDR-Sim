using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour {

    public Transform[] creatures;
    public Creature[] cs;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (Creature c in cs)
            {
                c.Talk();
            }
        }
	}

    public void Move(int creatureIndex)
    {
        creatures[creatureIndex].SendMessage("Move");
    }

    public void Talk(int creatureIndex)
    {
        creatures[creatureIndex].SendMessage("Talk");
    }

    public void Jump(int creatureIndex)
    {
        creatures[creatureIndex].SendMessage("Jump");
    }
}
