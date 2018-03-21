using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bernd : Human {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Cola cola = collider.gameObject.GetComponent<Cola>();
        Cigarettes cig = collider.gameObject.GetComponent<Cigarettes>();
        Beer beer = collider.gameObject.GetComponent<Beer>();
        Ketchup ketchup = collider.gameObject.GetComponent<Ketchup>();
        Soup soup = collider.gameObject.GetComponent<Soup>();
        Chocolate choc = collider.gameObject.GetComponent<Chocolate>();

        if (soup && dm.waitForItem)
        {

            soup.destroyed = true;
            dm.waitForItem = false;
            Destroy(soup.gameObject);
        }
        if (cig || beer || ketchup || cola || choc && dm.waitForItem)
        {
            dm.wrongItem = true;
            dm.dialogended = false;

        }
    }
}
