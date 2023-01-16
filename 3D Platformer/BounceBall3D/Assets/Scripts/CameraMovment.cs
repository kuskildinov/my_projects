using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        transform.position = playerTransform.position + offset;
    }
}
