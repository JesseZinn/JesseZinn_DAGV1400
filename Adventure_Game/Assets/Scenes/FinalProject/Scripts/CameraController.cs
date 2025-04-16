using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement playerMove;
    private Camera playerCam;

    private Vector3 currentCamera;
    private float cameraSize;
    public float speed = 5f;

    private void Start()
    {
        playerCam = GetComponent<Camera>();
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMovement>();
        cameraSize = playerCam.orthographicSize;
    }
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3f, player.transform.position.z - 10f);

        var step = speed * Time.deltaTime;
        if (playerMove.grounded == false)
        {
            float t = 0.5f * Time.deltaTime;
            cameraSize = Mathf.Lerp(cameraSize, cameraSize + 4f, t);
            //transform.position = Vector3.MoveTowards(transform.position, extendedCamera, step);
            Debug.Log("Zoooooom");
        }
        else
        {
            //cameraSize = Mathf.Lerp()
        }
    }
}
