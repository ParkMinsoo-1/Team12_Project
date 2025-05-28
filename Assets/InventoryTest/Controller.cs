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
        Getitem();
    }
    private void FixedUpdate()
    {

    }
    void TestCode()
    {
        float h = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float v = Input.GetAxisRaw("Vertical");   // W/S or Up/Down
        moveInput = new Vector3(h, 0f, v).normalized;
        interaction = Input.GetKeyDown(KeyCode.E);

        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    void Getitem()
    {
        Item item = GetComponent<Item>();
        if (interaction && item != null)
        {
            Debug.Log("Press E");
            InventoryManager.Instance.PickUp(item.ItemData);
            Destroy(gameObject);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    Item item = other.GetComponent<Item>();
    //    if (interaction && item != null)
    //    {
    //        InventoryManager.Instance.PickUp(item.ItemData);
    //        Destroy(other.gameObject);
    //    }
    //}

    // AddItem -> Inventory
    public void AddItem(ItemDataSO itemData)
    {
        testInventory.Add(itemData);
        Debug.Log($"[Player] 아이템 추가됨: {itemData.itemName}");
    }

}
