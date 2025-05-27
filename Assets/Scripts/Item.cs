using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemScriptable itemData;
    public ItemScriptable ItemData => itemData;
    private Item currentItem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentItem != null)
        {
            InventoryManager.Instance.PickUp(currentItem.ItemData);
            Destroy(currentItem.gameObject);
            currentItem = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
            currentItem = other.GetComponent<Item>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
            currentItem = null;
    }

    // TestDebug
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log($"아이템 id   : {itemData.id}");
    //        Debug.Log($"아이템 이름 : {itemData.itemName}");
    //        Debug.Log($"아이템 설명 : {itemData.description}");
    //        Debug.Log($"최대 스택   : {itemData.maxStack}");
    //        Debug.Log($"아이템 타입 : {itemData.itemtype}");
    //        Debug.Log($"아이템 가격 : {itemData.price}");
    //    }
    //}
}
