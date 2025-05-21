using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    public Transform player;
    private Rigidbody playerRB;
    public Vector3 Offset;
    public float speed;

    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        Vector3 playerForward = (playerRB.velocity + player.transform.forward).normalized;
        transform.position = Vector3.Lerp(transform.position,
            player.position + player.transform.TransformVector(Offset)
            + playerForward * (-10f),
            speed * Time.deltaTime);
        transform.LookAt(player);
    }
}