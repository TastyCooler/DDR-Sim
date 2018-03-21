using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Härher : Human {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Cola cola = collider.gameObject.GetComponent<Cola>();
        Cigarettes cig = collider.gameObject.GetComponent<Cigarettes>();
        Beer beer = collider.gameObject.GetComponent<Beer>();
        if (beer && dm.waitForItem)
        {

            beer.destroyed = true;
            dm.waitForItem = false;
            Destroy(beer.gameObject);
        }
        if (cig && dm.waitForItem)
        {
            dm.wrongItem = true;
            dm.dialogended = false;

        }
    }
}
