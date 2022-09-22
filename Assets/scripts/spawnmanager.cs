using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    public static spawnmanager Instance;
    public Transform PlayerPos;
    public void Awake()
    {
        Instance = this;
    }
}
