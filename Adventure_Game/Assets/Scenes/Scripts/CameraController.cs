using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private SimpleCharacterMovement playerMove;
    private Camera camera;

    private Vector3 extendedCamera;
    public float speed = 5f;

    private void Start()
    {
        camera = GetComponent<Camera>();
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<SimpleCharacterMovement>();
        extendedCamera = new Vector3(player.transform.position.x, player.transform.position.y + 3f, player.transform.position.z - 20f);
    }
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3f, player.transform.position.z - 10f);

        var step = speed * Time.deltaTime;
        if (playerMove.controller.isGrounded == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, extendedCamera, step);
            Debug.Log("Zoooooom");
        }
    }
}
