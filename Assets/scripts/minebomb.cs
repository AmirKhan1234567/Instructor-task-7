using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minebomb : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject explosionParticle;
    void Start()
    {
        
    }
    void Update()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            spawn1manager.Instance.playAudio();
            spawn1manager.Instance.Add();
            Instantiate(explosionParticle, transform.position, transform.rotation);
        }
    }
}
