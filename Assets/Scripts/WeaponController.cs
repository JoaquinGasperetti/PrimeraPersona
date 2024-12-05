using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform Punta;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public ParticleSystem Flash;
    public AudioSource Fuente;
    public AudioClip SonidoDisparo;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fuente.PlayOneShot(SonidoDisparo);
            var bullet = Instantiate(bulletPrefab, Punta.position, Punta.rotation);
            bullet.GetComponent<Rigidbody>().velocity = Punta.forward * bulletSpeed;
            Flash.Play();

        }
    }
}