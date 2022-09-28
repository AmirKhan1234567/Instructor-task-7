using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class fire : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject explosionParticle;                    
    void Start()
    {
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        rb.AddForce(Vector3.forward * 5f, ForceMode.Impulse);
       
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           
            spawn1manager.Instance.playAudio();
            Destroy(other.gameObject);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            spawn1manager.Instance.Add();
        }
    }
}