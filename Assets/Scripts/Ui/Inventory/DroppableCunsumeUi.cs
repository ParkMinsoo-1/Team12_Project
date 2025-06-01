using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DroppableCunsumeUi : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    protected Image image;
    protected RectTransform rect;
    
    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (image != null)
            image.color = Color.green;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (image != null)
            image.color = Color.white;
    }
    public virtual void OnDrop(PointerEventData eventData)
    {
        DraggableUi draggedItem = eventData.pointerDrag.GetComponent<DraggableUi>();

        if (draggedItem != null)
        {

            ItemDataSO droppedItemData = draggedItem.itemData;
            if (droppedItemData.itemtype == Itemtype.food)
            {
                PlayerManager.Instance.Player._status.Eat((int)droppedItemData.hunger);
                Destroy(draggedItem.gameObject);
            }
            
        }
    }
}
