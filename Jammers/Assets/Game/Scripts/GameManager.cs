using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform[] humans;
    public Human[] human;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (Human h in human)
            {
                h.Talk();
            }
        }
    }

    public void Move(int creatureIndex)
    {
        humans[creatureIndex].SendMessage("Move");
    }

    public void Talk(int creatureIndex)
    {
        humans[creatureIndex].SendMessage("Talk");
    }

    public void Jump(int creatureIndex)
    {
        humans[creatureIndex].SendMessage("Jump");
    }
}

