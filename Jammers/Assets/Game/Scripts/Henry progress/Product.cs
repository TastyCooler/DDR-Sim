using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : DragAndDrop {

    public float price = 0;
    DropOff drop;
    GameObject table;

    private void Start()
    {
        table = GameObject.Find("Table");
        drop = table.GetComponent<DropOff>();
    }

    void sellItem()
    {
        if (drop.laysOnTable)
        {

        }
    }
   
}
