using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PenguinCont : MonoBehaviour
{
    public delegate void PenguinPassedAction();
    public static event PenguinPassedAction OnPenguinPassedAction;
    
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 12f;

    private bool rotated;
    private int rotate;

    private void Awake()
    {
        if (transform.position.z > 1)
        {
            rotate = Random.Range(-10, 30);
        }
        else
        {
            rotate = Random.Range(-30, 10);
        }
    }

    private void FixedUpdate()
    {
        MoveTowardPlayer();
        if (!rotated)
        {
            if (transform.position.x > 10)
            {
                transform.Rotate(0, rotate, 0);
                rotated = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SFXManager._instance.PlaySound("Hit_Hurt");
            
            if (GameManager.ExtraLife == false)
            {
                Debug.Log("Game Over!");
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                DestroyClones();
                GameManager.PlayerScore++;
                GameManager.ExtraLife = false;
            }
        }
    }
    
    public void MoveTowardPlayer()
    {
        if (transform.position.x > player.transform.position.x)
        {
            OnPenguinPassedAction?.Invoke();
        }
        
        if (gameObject.transform.position.x < 27) 
        {
            gameObject.transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        }
        else
        {
            DestroyClones();
        }
    }
    
    public void DestroyClones()
    {
        Destroy(gameObject);
        GameManager.CurrentScore++;
    }
}