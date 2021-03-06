using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float movementX;
    private float movementY;
    private float turnY;
    public float turnSensitivity = 1f;
    public float speed = 1f;
    private Rigidbody rb;
    private int count;
    public int pickupAmount;
    public GameObject enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = transform.TransformDirection(Vector3.Normalize(new Vector3(movementX, 0, movementY)));
        //Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, turnY, 0));

        if (count == pickupAmount)
        {
            Destroy(enemy);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Pickup"))
        {
            
            other.gameObject.SetActive(false);
            count += 1;
        }
    }

    void OnLook(InputValue movementValue)
    {
        Vector2 lookValue = movementValue.Get<Vector2>();
        turnY = lookValue.x * turnSensitivity;
    }
}
