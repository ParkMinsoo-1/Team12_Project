using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemDataSO itemData;
    public ItemDataSO ItemData => itemData;

    [SerializeField] private float itemRotate;
    private void Update()
    {
        transform.Rotate(Vector3.up * itemRotate * Time.deltaTime);
    }
}
