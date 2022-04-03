using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform lookAt = null;
    [SerializeField] private Vector3 offset = Vector3.zero;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, lookAt.position + offset, Time.deltaTime);
    }
}

