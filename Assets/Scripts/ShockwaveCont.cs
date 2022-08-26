using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShockwaveCont : MonoBehaviour
{
    public delegate void OnBoss2Defeat();
    public static event OnBoss2Defeat OnBoss2DefeatedAction;
    
    [SerializeField] private int projSpeed = 12;
    private bool lastProj;
    
    private void FixedUpdate()
    {
        MoveProj();
    }

    private void OnEnable()
    {
        Boss2Cont.OnLastProjSpawnedAction += OnLastProjSpawnedAction;
    }

    private void OnDisable()
    {
        Boss2Cont.OnLastProjSpawnedAction -= OnLastProjSpawnedAction;
    }

    private void OnLastProjSpawnedAction()
    {
        if (transform.position.x < -8)
        {
            lastProj = true;
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
        if (lastProj)
        {
            OnBoss2DefeatedAction?.Invoke();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}


