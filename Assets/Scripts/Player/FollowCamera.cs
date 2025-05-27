using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Camera.main.orthographic = true;
        
        
        transform.position = targetPosition;
    }
}
