using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tom : Human {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Cola cola = collider.gameObject.GetComponent<Cola>();
        Cigarettes cig = collider.gameObject.GetComponent<Cigarettes>();
        Chocolate choc = collider.gameObject.GetComponent<Chocolate>();
        if (choc && dm.waitForItem)
        {

            choc.destroyed = true;
            dm.waitForItem = false;
            Destroy(choc.gameObject);
        }
        if (cola || cig && dm.waitForItem)
        {
            dm.wrongItem = true;
            dm.dialogended = false;

        }
    }
}
