using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class spawn1manager : MonoBehaviour
{
    public static spawn1manager Instance;
    public GameObject enemy;
    public GameObject bomb;
    public int enemyCount;
    public int waveCount = 1;
    public AudioClip clip;
    public AudioSource audio;
    public TMP_Text currentscore;
    public int score = 0;
    public TMP_Text healths;
    public int health = 10;
    public GameObject mine;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        currentscore.text = score.ToString();
    }
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy1move>().Length;
        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveCount);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bomb, new Vector3(player1move.instance.transform.position.x, player1move.instance.transform.position.y + 2, player1move.instance.transform.position.z), player1move.instance.transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
           
                    Instantiate(mine, new Vector3(player1move.instance.transform.position.x+1, player1move.instance.transform.position.y, player1move.instance.transform.position.z+1), player1move.instance.transform.rotation);
                
            
        }
    }
    void SpawnEnemyWave(int enemytospawn)
    {
        for (int i = 0; i < enemytospawn; i++)
        {
            Instantiate(enemy, GenerateSpawnPosition(), enemy.transform.rotation);
        }
        waveCount++;
    }
    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-20, 20);
        float zPos = Random.Range(-10, 10);
        return new Vector3(xPos, 0, zPos);
    }
    public void playAudio()
    {
        audio.PlayOneShot(clip);
    }
    public void Add()
    {
        score += 25;
        currentscore.text = score.ToString();
    }
    public void healthloss()
    {
        health -= 1;
        healths.text = health.ToString();

    }
    public void enemyfire()
    {
        Instantiate(bomb, new Vector3(player1move.instance.transform.position.x, player1move.instance.transform.position.y + 2, player1move.instance.transform.position.z), player1move.instance.transform.rotation);
    }
}
