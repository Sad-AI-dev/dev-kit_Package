using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [Header("Settings")]
    public Vector3 moveDirection;
    [SerializeField] private bool moveOnStart = true;

    //states
    private bool moving;

    //external
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (moveOnStart) StartMove();
    }

    //----------states------------
    public void StartMove()
    {
        moving = true;
    }

    public void StopMove()
    {
        moving = false;
    }

    //----------movement----------
    private void FixedUpdate()
    {
        if (moving) Move();
    }

    private void Move()
    {
        Vector3 speed = moveDirection * (100 * Time.deltaTime);
        rb.velocity = transform.right * speed.x + transform.up * speed.y + transform.forward * speed.z; //convert to local space
    }
}
