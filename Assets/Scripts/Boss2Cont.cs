using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2Cont : MonoBehaviour
{
    public delegate void OnLastProjSpawned();
    public static event OnLastProjSpawned OnLastProjSpawnedAction;
    
    private int speed = 5;
    private int jumpSpeed = 10;
    private bool moveDown;
    private bool move = true;
    private int numOfJumps;
    private bool moveLeft;
    
    [SerializeField] private GameObject shockwave;
    [SerializeField] private Transform shockSpawn;
    
    private void FixedUpdate()
    {
        if (numOfJumps < 10)
        {
            MoveBoss();
        }
    }

    private void MoveBoss()
    {
        if (transform.position.z > 3.5)
        {
            move = false;
            Jump();
            moveLeft = true;
        }
        if (transform.position.z < -3.5)
        {
            move = false;
            Jump();
            moveLeft = false;
        }

        if (move)
        {
            if (moveLeft)
            {
                transform.Translate(Vector3.right * (Time.deltaTime * speed));
            }
            else
            {
                transform.Translate(Vector3.left * (Time.deltaTime * speed));
            }
        }
    }
    
    void Jump()
    {
        SFXManager._instance.PlaySound("Boss2Jump");
        
        if (transform.position.y > 3)
        {
            moveDown = true;
        }

        if (transform.position.y < 0)
        {
            moveDown = false;
            SpawnShockwave();
            if (numOfJumps == 9)
            {
                OnLastProjSpawnedAction?.Invoke();
            }
            numOfJumps++;
            move = true;
        }

        if (!moveDown)
        {
            transform.Translate(Vector3.up * (Time.deltaTime * jumpSpeed));
        }
        else
        {
            transform.Translate(Vector3.down * (Time.deltaTime * jumpSpeed));
        }
    }
    
    void SpawnShockwave()
    {
        GameObject projClone = Instantiate(shockwave, shockSpawn.transform.position, Quaternion.Euler(0, 0, 0));
    }
}
