using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour
{
    [SerializeField] private List<ItemScriptable> testInventory = new List<ItemScriptable>();

    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 moveInput;

    private void Awake()
    {
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
        float h = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float v = Input.GetAxisRaw("Vertical");   // W/S or Up/Down
        moveInput = new Vector3(h, 0f, v).normalized;

        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            InventoryManager.Instance.PickUp(item.ItemData);
            Destroy(other.gameObject);
        }
    }

    // AddItem -> Inventory
    public void AddItem(ItemScriptable itemData)
    {
        testInventory.Add(itemData);
        Debug.Log($"[Player] 아이템 추가됨: {itemData.itemName}");
    }

}
