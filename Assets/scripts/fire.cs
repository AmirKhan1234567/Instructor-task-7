using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class fire : MonoBehaviour
{
    public float radius;
    public LayerMask enemyMask;
    public List<Collider> enemies;
    public Rigidbody rb;
    public GameObject explosionParticle;
    void Start()
    {
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        rb.AddForce(Vector3.forward * 5f, ForceMode.Impulse);
        StartCoroutine(Blast());
    }
    IEnumerator Blast()
    {
        yield return new WaitForSeconds(3f);
        enemies = Physics.OverlapSphere(transform.position, radius, enemyMask).ToList();
        if (enemies.Count != 0)
        {
            Debug.Log(enemyMask);

            foreach (Collider c in enemies)
            {
                if (c.GetComponent<Enemy1move>() != null)
                {
                    c.GetComponent<Enemy1move>().DestroyObject();

                }
            }
        }
        //Instantiate(particleEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("play sound");
            spawn1manager.Instance.playAudio();
            Destroy(other.gameObject);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            spawn1manager.Instance.Add();
        }
    }
    
}