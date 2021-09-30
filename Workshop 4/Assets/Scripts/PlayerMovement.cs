using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float movementX;
    private float movementY;
    public float speed = 1f;
    private Rigidbody rb;
    private int count;
    public int pickupAmount;

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
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
        if (count == pickupAmount)
        {
            //destroy enemy
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

}
