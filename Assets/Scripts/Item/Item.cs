using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemDataSO itemData;
    public ItemDataSO ItemData => itemData; 
    //[SerializeField] private float itemRotate;

    //void Update()
    //{
    //    // item Idle Rotate
    //    transform.Rotate(Vector3.up * itemRotate * Time.deltaTime);
    //}
    public void RemoveItem()
    {
        Destroy(this.gameObject);
    }
}
