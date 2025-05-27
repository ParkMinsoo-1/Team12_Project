using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject player;

    void LateUpdate()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, Mathf.Infinity, 1 << 6);

        if (hits == null) return;

        List<TransparentObject> obj = new List<TransparentObject>();
        TransparentObject[] objs;


        for (int i = 0; i < hits.Length; i++)
        {
            objs = hits[i].transform.GetComponentsInChildren<TransparentObject>();
            foreach (TransparentObject obj2 in objs)
            {
                obj2?.BecomeTransparent();
            }
        }
    }
}
