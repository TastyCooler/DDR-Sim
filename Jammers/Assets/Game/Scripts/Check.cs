using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    DropOff drop;
    private void Start()
    {
        drop = GetComponent<DropOff>();
    }
    private void Update()
    {
        Checker();
    }

    void Checker()
    {
        if (drop.transform.childCount == 0)
        {
            drop.oneObjectOnly = true;
            drop.laysOnTable = false;
        }
        Debug.LogFormat("laysOnTable{0}", drop.laysOnTable);
    }
}
