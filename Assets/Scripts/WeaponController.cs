using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform Punta;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bullet = Instantiate(bulletPrefab, Punta.position, Punta.rotation);
            bullet.GetComponent<Rigidbody>().velocity = Punta.forward * bulletSpeed;
        }
    }
}