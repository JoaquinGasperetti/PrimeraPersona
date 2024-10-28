using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float WalkSpeed = 5f;
    public float AlturaSalto = 2f;
    public float Graity = -20f;

    Vector3 MoveInput = Vector3.zero;
    CharacterController charactercontroller;

    private void Awake()
    {
        charactercontroller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (charactercontroller.isGrounded)
        {
            MoveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            MoveInput = transform.TransformDirection(MoveInput) * WalkSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                MoveInput.y = Mathf.Sqrt(AlturaSalto * 2f * Graity);
            }
        }

        MoveInput.y += Graity * Time.deltaTime;
        charactercontroller.Move(MoveInput * Time.deltaTime);
    }
}
