using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matthias : Human {


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Cola cola = collider.gameObject.GetComponent<Cola>();
        if (cola && dm.waitForItem)
        {
            dm.dialogended = true;
            cola.destroyed = true;
            Destroy(cola.gameObject);
        }
    }

    



}
