using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour //Code Made By Domi.theDev(www.youtube.com/@domi.thedev)
{
    public float speed;
    public float rotationSpeed;
    Animator animator;

    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb= GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (horizontalInput != 0)
        {
            animator.SetBool("isMoving", true);
        }

        else if (verticalInput != 0)
        {
            animator.SetBool("isMoving", true);
        }

        else
        {
            animator.SetBool("isMoving", false);
        }

        rb.velocity = movementDirection * speed;
      
    }

  





    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {

            animator.SetTrigger("Death");
            speed = 0;
            rotationSpeed = 0;
        }

   
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            animator.SetTrigger("Attacking");
        }
    }




}
