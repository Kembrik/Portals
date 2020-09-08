using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public float speed = 1.0f;
    public float way = 10.0f;
    private Vector3 moveCube = Vector3.zero;
    private Vector3 startPoint;
    private CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        startPoint = controller.transform.position;
    }

    private void Update()
    {
        moveCube = new Vector3(way * speed, 0, 0);
        moveCube = transform.TransformDirection(moveCube);
        controller.Move(moveCube * Time.deltaTime);

        if (Mathf.Abs(way) < (controller.transform.position.x - startPoint.x) || (controller.transform.position.x - startPoint.x) < 0)
        {
            way = -way;
        }

    }
}
