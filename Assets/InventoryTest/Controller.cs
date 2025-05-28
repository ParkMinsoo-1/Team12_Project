using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour
{
    [SerializeField] private List<ItemDataSO> testInventory = new List<ItemDataSO>();

    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 moveInput;

    bool interaction = false;

    private void Awake()
    {
        TestInventory tinventory = InventoryManager.Instance.inventory;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        TestCode();
    }
    private void FixedUpdate()
    {

    }
    void TestCode()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        moveInput = new Vector3(h, 0f, v).normalized;

        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (interaction && item != null)
        {
            InventoryManager.Instance.PickUp(item.ItemData);
            Destroy(other.gameObject);
        }
    }

    // AddItem -> Inventory
    public void AddItem(ItemDataSO itemData)
    {
        testInventory.Add(itemData);
        Debug.Log($"[Player] ������ �߰���: {itemData.itemName}");
    }

}
