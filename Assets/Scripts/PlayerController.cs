using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick js;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;
    
    void Start()
    {
        animator = GetComponent<Animator>();    
    }
    private void FixedUpdate() 
    {
        rb.velocity = new Vector3(js.Horizontal * moveSpeed, rb.velocity.y, js.Vertical * moveSpeed);

        if(js.Horizontal != 0 || js.Vertical != 0)
        {
            animator.SetBool("isMoving", true);
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
