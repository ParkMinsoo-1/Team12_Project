using UnityEngine;
using static UnityEditor.Progress;

public class HarvestData : MonoBehaviour
{
    [SerializeField] private HarvestableObjectSO harvestData;
    [SerializeField] private int currentHp;
    private void Start()
    {
        currentHp = harvestData.maxHp;
    }

    public void TakeDamage(int amount)
    {
        currentHp -= amount;
        if (currentHp <= 0)
        {
            DropItem();
            Destroy(gameObject);
        }
    }

    private void DropItem()
    {
        Item item = GetComponent<Item>();
        if (item != null)
            InventoryManager.Instance.PickUp(item.ItemData);
    }
}
