using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCube : MonoBehaviour
{
    public float speed = 6.0f;
    public float way = 10.0f;
    private Vector3 moveCube = Vector3.zero;
    private CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        moveCube = new Vector3(way * speed, 0, 0);
        moveCube = transform.TransformDirection(moveCube);
        controller.Move(moveCube * Time.deltaTime);
    }
}
