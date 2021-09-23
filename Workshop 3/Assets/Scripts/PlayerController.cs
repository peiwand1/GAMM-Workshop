using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 4;

    private Rigidbody rb;
    Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = transform.position;
    }

    void OnMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            pos = hit.point;
            Debug.Log(pos);
        }
    }


    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
    }
}
