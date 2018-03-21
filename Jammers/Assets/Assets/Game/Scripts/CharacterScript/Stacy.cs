using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacy : Human {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Cola cola = collider.gameObject.GetComponent<Cola>();
        Cigarettes cig = collider.gameObject.GetComponent<Cigarettes>();

        if (cig && dm.waitForItem)
        {

            cig.destroyed = true;
            dm.waitForItem = false;
            Destroy(cig.gameObject);
        }
        if (cola && dm.waitForItem)
        {
            dm.wrongItem = true;
            dm.dialogended = false;

        }
    }
}
