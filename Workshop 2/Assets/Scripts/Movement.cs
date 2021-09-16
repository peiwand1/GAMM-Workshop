using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Vector2 moveDirection;  
    public float moveSpeed = 2;

    public void onMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    
    }
    void Move(Vector2 direction)
    {
        transform.Translate(direction.x * moveSpeed * Time.deltaTime,0,direction.y * moveSpeed * Time.deltaTime);
    } 

    void Start(){
        

    }

    void Update()
    {
        Move(moveDirection);
    }
}
