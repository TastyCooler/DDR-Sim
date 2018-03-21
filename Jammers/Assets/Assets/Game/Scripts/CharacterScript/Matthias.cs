using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matthias : Human {

    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Cola cola = collider.gameObject.GetComponent<Cola>();
        Cigarettes cig = collider.gameObject.GetComponent<Cigarettes>();
        
        if (cola && dm.waitForItem)
        {
            
            cola.destroyed = true;
            dm.waitForItem = false;
            Destroy(cola.gameObject);
        }
        if (cig && dm.waitForItem)
        {
            dm.wrongItem = true;
            dm.dialogended = false;
       
        }
    }

    



}
