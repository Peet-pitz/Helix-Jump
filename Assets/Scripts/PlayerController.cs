using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private AudioManager audioManager;

    public GameObject[] ballPrefab;
    private float spawnRandom;
    public int enemyCount;
    public int numberOfBalls;
    public float ballDistance = 5;
    public float ySpawn = 0;

    private float bounceForce = 6; 
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();

        numberOfBalls = GameManager.currentLevelIndex + 1;
        //spawn helix rings
        for (int i = 0; i < numberOfBalls; i++)
        {
            if (i == 0)
                SpawnBall(0);
            else
                SpawnBall(UnityEngine.Random.Range(0, ballPrefab.Length));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnBall(int ballIndex)
    {
        /* GameObject go = Instantiate(ballPrefab[ballIndex], transform.up * ySpawn, Quaternion.identity);
         go.transform.parent = transform;
         ySpawn -= ballDistance;*/
    }

    public void GameDifficulty(int difficulty)
    {
        //bounceForce *= difficulty;
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("Bounce");
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Safe (Instance)")
        {
            //The ball hits the safe area
        }else if(materialName == "Unsafe (Instance)")
        {
            //The ball hits the unsafe area
            GameManager.gameOver = true;
            audioManager.Play("GameOver");
        }
        else if(materialName == "Last Ring (Instance)" && !GameManager.levelCompleted)
        {
            //we completed the level
            GameManager.levelCompleted = true;
            audioManager.Play("Win");
        }
    }
}
