using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private AudioManager audioManager;

    private float bounceForce = 6;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("Bounce");
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Safe (Instance)")
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
