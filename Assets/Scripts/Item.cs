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
}
