using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;

    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = target.position.x;
        transform.position = newPosition;
    }
}
