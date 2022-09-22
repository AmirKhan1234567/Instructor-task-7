using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1move : MonoBehaviour
{
    private Animator anim;
    public UnityEngine.AI.NavMeshAgent agent;
    private Vector3 playerpos;
    public static Enemy1move Instance;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (player1move.instance != null)
        {
            playerpos = player1move.instance.transform.position;
            agent.SetDestination(playerpos);
        }
    }
    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
