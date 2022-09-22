using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent Enemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Enemy.SetDestination(spawnmanager.Instance.PlayerPos.position);
    }
}
