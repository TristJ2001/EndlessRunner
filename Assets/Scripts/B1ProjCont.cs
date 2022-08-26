
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B1ProjCont : MonoBehaviour
{
    public delegate void OnBoss1Defeat();
    public static event OnBoss1Defeat OnBoss1DefeatedAction;
    
    [SerializeField] private int projSpeed = 12;

    public bool lastSnowball;
    
    private void FixedUpdate()
    {
        MoveProj();
    }

    private void OnEnable()
    {
        Boss1Cont.OnLastSnowballSpawnedAction += OnLastSnowballSpawnedAction;
    }

    private void OnDisable()
    {
        Boss1Cont.OnLastSnowballSpawnedAction -= OnLastSnowballSpawnedAction;
    }

    private void OnLastSnowballSpawnedAction()
    {
        if (transform.position.x < -8)
        {
            lastSnowball = true;
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
                DestroyProj();
                GameManager.ExtraLife = false;
            }
        }
    }
    
    void MoveProj()
    {
        if (transform.position.x < 27) 
        {
            transform.Translate(Vector3.right * (Time.deltaTime * projSpeed));
        }
        else
        {
            DestroyProj();
        }
    }

     void DestroyProj()
    {
        if (lastSnowball)
        {
            OnBoss1DefeatedAction?.Invoke();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

