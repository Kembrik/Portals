using UnityEngine;

public class PlayerTopDown : MonoBehaviour
{
    private Rigidbody componentRigidbody;
    private Vector3 moveDirection = Vector3.zero;

    public int TurnSpeed = 2;

    private void Start()
    {
        componentRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        componentRigidbody.AddForce(moveDirection * TurnSpeed);
    }
}
