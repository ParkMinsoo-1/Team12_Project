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
    //        Debug.Log($"������ id   : {itemData.id}");
    //        Debug.Log($"������ �̸� : {itemData.itemName}");
    //        Debug.Log($"������ ���� : {itemData.description}");
    //        Debug.Log($"�ִ� ����   : {itemData.maxStack}");
    //        Debug.Log($"������ Ÿ�� : {itemData.itemtype}");
    //        Debug.Log($"������ ���� : {itemData.price}");
    //    }
    //}
}
