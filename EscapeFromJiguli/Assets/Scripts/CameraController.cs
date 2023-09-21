using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform transf_player;
    
    private void Update()
    {
        transform.position = new Vector3(transf_player.position.x, transf_player.position.y, transform.position.z);
    }
}
