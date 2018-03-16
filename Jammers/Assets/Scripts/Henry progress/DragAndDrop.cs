using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler {

    #region Fields

    // Need to save the parent position(Inventory) of the object to set it back
    [HideInInspector] public Transform returnToParent;

    // Need to unblock raycast when dragging a canves object
    private bool blockRay;

    #endregion

    /// <summary>
    /// Comparable with Start() function, stuff it needs to do before dragging an canves object
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Saving parent position(Inventory) where it came from
        returnToParent = this.transform.parent;

        // Set object out of parent position(Inventory), however, still in canves
        this.transform.SetParent(this.transform.parent.parent);

        // Stop canves object from blocking the raycast coming from mouse
        blockRay = false;
        GetComponent<CanvasGroup>().blocksRaycasts = blockRay;
    }

    /// <summary>
    /// Holding mouse 0 on the canves object will parent it to mouse
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        // Set canves object to mouseposition
        this.transform.position = eventData.position;
    }

    /// <summary>
    /// Release canves object will parent it back to initially parent position(Inventory)
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        // Set position back to parent position(Inventory)
        this.transform.SetParent(returnToParent);

        // Enable canves object to block raycast
        blockRay = true;
        GetComponent<CanvasGroup>().blocksRaycasts = blockRay;
    }
}
