using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_test
{
    public class CameraMoveScript : MonoBehaviour
    {
    [SerializeField] private Transform player_position;

    private Vector3 cameraOffset;

    private void Start()
    {
        cameraOffset = transform.position - player_position.position;
    }
    private void Update()
    {
        transform.position = player_position.position + cameraOffset;
    }
  }
}


