using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Härher : Human {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Cola cola = collider.gameObject.GetComponent<Cola>();
        Cigarettes cig = collider.gameObject.GetComponent<Cigarettes>();
        Beer beer = collider.gameObject.GetComponent<Beer>();
        Ketchup ketchup = collider.gameObject.GetComponent<Ketchup>();
        Soup soup = collider.gameObject.GetComponent<Soup>();
        Chocolate choc = collider.gameObject.GetComponent<Chocolate>();
        if (beer && dm.waitForItem)
        {

            beer.destroyed = true;
            dm.waitForItem = false;
            Destroy(beer.gameObject);
        }
        if (cola || ketchup || soup || choc || cig && dm.waitForItem)
        {
            dm.wrongItem = true;
            dm.dialogended = false;

        }
    }
}
