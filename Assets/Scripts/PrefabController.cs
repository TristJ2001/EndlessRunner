
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabController : MonoBehaviour
{
    public delegate void PrefabPassedAction();
    public static event PrefabPassedAction OnPrefabPassedAction;
    
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 12f;
    
    private void FixedUpdate()
    {
        MoveTowardPlayer();
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
            Passed(); 
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

    public void Passed()
    {
        OnPrefabPassedAction?.Invoke();
    }
    
    public void DestroyClones()
    {
        Destroy(gameObject);
        GameManager.CurrentScore++;
    }
}
