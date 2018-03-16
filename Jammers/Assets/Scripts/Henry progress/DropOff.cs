using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropOff : MonoBehaviour, IDropHandler {

    // Reference to DragAndDrop script
    DragAndDrop drop;

    public void OnDrop(PointerEventData eventData)
    {
        drop = eventData.pointerDrag.GetComponent<DragAndDrop>();
        if(drop != null)
        {
            drop.returnToParent = this.transform;
        }
    }
}
