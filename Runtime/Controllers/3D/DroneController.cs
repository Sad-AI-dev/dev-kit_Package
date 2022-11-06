using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DevKit {
[RequireComponent(typeof(Rigidbody))]
public class DroneController : MonoBehaviour
{
    [Header("Horizontal movement")]
    public float horTopSpeed;
    public float horAcceleration;
    public float horDeceleration;
    [Space(10f)]
    public UnityEvent<Vector2> onChangeHorMoveDir;
    //horizontal move vars
    Vector2 horMoveDir;
    float horSpeed;

    [Header("Vertical movement")]
    public float verTopSpeed;
    public float verAcceleration;
    public float verDeceleration;
    [Space(10f)]
    public UnityEvent<float> OnChangeVerMoveDir;
    //vertical move vars
    float verMoveDir;
    float verSpeed;

    //external components
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //---------read inputs-----------
    public void SetHorMoveDir(Vector2 dir)
    {
        if (dir.magnitude > 1f) { dir.Normalize(); } //force dir in expected bounds
        if (dir != horMoveDir) { onChangeHorMoveDir?.Invoke(dir); }
        horMoveDir = dir;
    }

    public void SetVerMoveDir(float dir)
    {
        dir = Mathf.Clamp(dir, -1f, 1f); //force dir in expected bounds
        if (dir != verMoveDir) { OnChangeVerMoveDir?.Invoke(dir); }
        verMoveDir = dir;
    }

    //----------main update loop-------------
    private void FixedUpdate()
    {
        //hor movement
        UpdateHorSpeed();
        MoveHor();
        //ver movement
        UpdateVerSpeed();
        MoveVer();
    }

    //---------------horizontal movement----------------
    private void UpdateHorSpeed()
    {
        if (horMoveDir.magnitude > 0.1f) { horSpeed += horAcceleration; } //accelerate
        else { horSpeed -= horDeceleration; } //deceleration
        horSpeed = Mathf.Clamp(horSpeed, 0, horTopSpeed);
    }

    private void MoveHor()
    {
        Vector2 toMove;
        float speed = horSpeed * Time.deltaTime * 100;
        if (horMoveDir.magnitude > 0.1f) { toMove = horMoveDir * speed; } //don't allow stop through moveDir
        else { toMove = new Vector2(rb.velocity.x, rb.velocity.z).normalized * speed; } //use old direction when there is no direct moveDir
        //output result
        Vector3 result = transform.right * toMove.x + transform.forward * toMove.y;
        rb.velocity = new Vector3(result.x, rb.velocity.y, result.z);
    }

    //----------------vertical movement-----------------
    private void UpdateVerSpeed()
    {
        if (Mathf.Abs(verMoveDir) > 0.1f) { verSpeed += verAcceleration; } //accelerate
        else { verSpeed -= verDeceleration; } //deceleration
        verSpeed = Mathf.Clamp(verSpeed, 0, verTopSpeed);
    }

    private void MoveVer()
    {
        float toMove = verSpeed * Time.deltaTime * 100;
        if (Mathf.Abs(verMoveDir) > 0.1f) { toMove *= verMoveDir; } //don't allow stop through moveDir
        else { toMove *= Mathf.Clamp(rb.velocity.y, -1f, 1f); } //use old direction when there is no direct moveDir
        //output result
        rb.velocity = new Vector3(rb.velocity.x, toMove, rb.velocity.z);
    }
}
}