using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropOff : MonoBehaviour, IDropHandler {

    // Reference to DragAndDrop script
    DragAndDrop drop;

    // Need to save location to set it back when someone put another object on Table
    [HideInInspector] public Transform returnObject;

    private bool occupied = false;

    public void OnDrop(PointerEventData eventData)
    {
        // Reference to DragAndDrop pointer
        drop = eventData.pointerDrag.GetComponent<DragAndDrop>();

        // verify if the ray/pointer hits something
        if (drop != null)
        {
            returnObject = drop.returnToParent;

            // Parent canves object to parent position(Table)
            drop.returnToParent = transform;
        }
    }
}
