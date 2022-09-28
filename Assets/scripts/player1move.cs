using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1move : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public static player1move instance;
    public Animator animator;
    public GameObject explosionParticle;
    private Vector3 startpos;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        startpos = transform.position;
    }
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                animator.SetTrigger("run");

            }
        }
        else
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                animator.SetTrigger("idle");

            }
        }
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.fixedDeltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
         
            spawn1manager.Instance.healthloss();
            spawn1manager.Instance.playAudio();
            Instantiate(explosionParticle, transform.position, transform.rotation);
            transform.position = startpos;
        }
        else if(other.gameObject.CompareTag("wall"))
        {
           
            spawn1manager.Instance.healthloss();
            spawn1manager.Instance.playAudio();
            Instantiate(explosionParticle, transform.position, transform.rotation);
            transform.position = startpos;
        }
        
    }
}

