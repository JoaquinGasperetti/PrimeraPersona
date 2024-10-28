using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Referencias:")]
    public Camera playerCamera;

    [Header("Variables movimiento:")]
    public float WalkSpeed = 5f;
    public float RunSpeed = 10f;

    [Header("Variables de rotacion:")]
    public float SensivilidadCamara;

    // Variables privadas:
    Vector3 MoveInput = Vector3.zero;
    CharacterController charactercontroller;
    Vector3 InputRotacion = Vector3.zero;
    private float AnguloVerticalCam;

    private void Awake()
    {
        charactercontroller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Move();
        Mirar();
    }

    private void Move() //Funcion de movimiento 
    {
        MoveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MoveInput = transform.TransformDirection(MoveInput) * WalkSpeed;
        charactercontroller.Move(MoveInput * Time.deltaTime);
    }

    private void Mirar() //Funcion de el movimiento de la cámara
    {
        InputRotacion.x = Input.GetAxis("Mouse X") * SensivilidadCamara * Time.deltaTime;
        InputRotacion.y = Input.GetAxis("Mouse Y") * SensivilidadCamara * Time.deltaTime;
        AnguloVerticalCam += InputRotacion.y;
        AnguloVerticalCam = Mathf.Clamp(AnguloVerticalCam, -70, 70);
        transform.Rotate(Vector3.up * InputRotacion.x);
        playerCamera.transform.localRotation = Quaternion.Euler(-AnguloVerticalCam, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("win"))
        {
            SceneManager.LoadScene("Victoria");
        }
    }
}
