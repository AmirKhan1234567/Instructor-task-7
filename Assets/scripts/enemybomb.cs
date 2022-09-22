using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybomb : MonoBehaviour
{
    public GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("enemyfire", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void enemyfire()
    {
        Instantiate(bomb, new Vector3(Enemy1move.Instance.transform.position.x, Enemy1move.Instance.transform.position.y + 2, Enemy1move.Instance.transform.position.z), Enemy1move.Instance.transform.rotation);
    }

    
}
