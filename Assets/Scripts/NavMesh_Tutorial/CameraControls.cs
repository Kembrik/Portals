using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float speed = 6.0f;
    public float boostSpeed = 5.0f;
    public float jumpSpeed = 8.0f;
    public float rotateSpeed = 1.5f;
    public float gravity = 0.0f;

    private Vector3 moveDirection = Vector3.zero;

    private CharacterController controller;
    // private Transform playerCamera;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        // playerCamera = GetComponent<Camera>().transform;


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0, Space.World);
        // transform.Rotate(0, -Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime, 0);

        transform.Rotate(-Input.GetAxis("Mouse Y") * rotateSpeed, 0, 0);
        // transform.Rotate(Input.GetAxis("Mouse X") * rotationspeed * Time.deltaTime, 0, 0, Space.World);

        if (Input.GetKeyDown(KeyCode.LeftShift)) speed *= boostSpeed;
        if (Input.GetKeyUp(KeyCode.LeftShift)) speed /= boostSpeed;


        moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, moveDirection.y, Input.GetAxis("Vertical") * speed);
        moveDirection = transform.TransformDirection(moveDirection);


        if (Input.GetButton("Jump")) moveDirection.y = jumpSpeed;
        else if (Input.GetKey(KeyCode.LeftControl)) moveDirection.y = -jumpSpeed;
        else moveDirection.y = 0;

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
