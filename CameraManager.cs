using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Transform player;

    public Vector3 Offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position + Offset;
    }
}
