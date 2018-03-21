using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stefan : Human {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Cola cola = collider.gameObject.GetComponent<Cola>();
        Cigarettes cig = collider.gameObject.GetComponent<Cigarettes>();
        Beer beer = collider.gameObject.GetComponent<Beer>();
        Ketchup ketchup = collider.gameObject.GetComponent<Ketchup>();
        if (ketchup && dm.waitForItem)
        {

            ketchup.destroyed = true;
            dm.waitForItem = false;
            Destroy(ketchup.gameObject);
        }
        if (cola || cig || beer && dm.waitForItem)
        {
            dm.wrongItem = true;
            dm.dialogended = false;

        }
    }
}
