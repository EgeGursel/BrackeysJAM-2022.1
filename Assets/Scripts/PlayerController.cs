using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PUT THIS SCRIPT ON PLAYER GAME OBJECT SO IT CAN MOVE

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D _rb;
    private Animator _anim;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // ANIMATE THE PLAYER IN ACCORDANCE TO IT'S RIGIDBODY2D'S VELOCITY
    void Update()
    {
        _anim.SetFloat("Horizontal", _rb.velocity.x);
    }

    // MAKE PLAYER LOOK AT THE CURSOR AND MOVE FORWARD
    void FixedUpdate()
    {
        // TRANSFORM ROTATION TO CURSOR POSITION
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        // MOVE FORWARD
        _rb.velocity = transform.right * moveSpeed;
    }
}