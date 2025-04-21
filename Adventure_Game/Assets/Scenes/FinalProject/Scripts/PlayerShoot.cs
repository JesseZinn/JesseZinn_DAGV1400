using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public FlipTransformBehavior playerFlipScript;

    public float bulletSpeed;
    public float fireRate;

    private bool readyToShoot;

    private void Start()
    {
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();
    }
    private void MyInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && readyToShoot)
        {
            readyToShoot = false;
            Shoot();
        }
    }
    private void Shoot()
    {
        Vector3 targetPoint;

        if (playerFlipScript.right)
        {
            targetPoint = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
        }
        else if (playerFlipScript.left)
        {
            targetPoint = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z);
        }
        else
        {
            Debug.Log("Error: Direction not set");
            return;
        }

        Vector3 direction = targetPoint - transform.position;

        GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);

        if (currentBullet.GetComponent<Rigidbody>())
        {
            currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * bulletSpeed * 100f, ForceMode.Force);
        }

        Invoke("ResetShot", fireRate);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
}
