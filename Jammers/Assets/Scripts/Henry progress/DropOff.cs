using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropOff : MonoBehaviour, IDropHandler {

    #region Fields

    // Reference to DragAndDrop script
    DragAndDrop drop;

<<<<<<< HEAD
    // Need to save location to set it back when someone put another object on Table
    [HideInInspector] public Transform returnObject;

    private bool occupied = false;
=======
    // Toggle on to let only one object on parent object(Inventory or Table)
    public bool oneObjectOnly       = false;

    // Toggle on to let more object on parent object(Inventory or Table)
    public bool moreThenOneObject   = false;

    // Parent Object(Inventory or Table) is occupied
    private bool accessOnObject     = true;

    #endregion
>>>>>>> 53914b9ed0336459f2cef0763d9951550df597d7

    public void OnDrop(PointerEventData eventData)
    {
        // Reference to DragAndDrop pointer
        drop = eventData.pointerDrag.GetComponent<DragAndDrop>();

<<<<<<< HEAD
        // verify if the ray/pointer hits something
        if (drop != null)
        {
            returnObject = drop.returnToParent;

            // Parent canves object to parent position(Table)
            drop.returnToParent = transform;
=======
        // Look if parent position(Table) is occupied
        if (accessOnObject)
        {
            // Let objects placeable on parent object(Inventory)
            if (moreThenOneObject)
            {
                if (drop != null)
                {
                    // place object on parent position(Inventory)
                    drop.returnToParent = transform;
                }
            }

            // Look if theres already an child object in the parent object(Table)
            if (transform.childCount < 1)
            {
                oneObjectOnly = true;
            }

            // Let and object droppable and prohibit to drop anything if theres something
            if (oneObjectOnly)
            {
                // Verify if there is an parent position(Table) to drop it off
                if (drop != null)
                {

                    // place object on parent position(Table)
                    drop.returnToParent = transform;
                    oneObjectOnly = false;
                }
            }
>>>>>>> 53914b9ed0336459f2cef0763d9951550df597d7
        }
    }
}
