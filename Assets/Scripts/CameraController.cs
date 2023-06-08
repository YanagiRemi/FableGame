using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;

    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(target.position.x, -5, 6);
        transform.position = newPosition;
    }
}
