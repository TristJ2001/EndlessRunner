using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PiranhaCont : MonoBehaviour
{
    public delegate void PiranhaPassedAction();
    public static event PiranhaPassedAction OnPiranhaPassedAction;
    
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 12f;

    private int rotate1 = -10;
    private int rotate2 = 20;
    private bool rotated1;
    private bool rotated2;
    
    private void FixedUpdate()
    {
        MoveTowardPlayer();
        
        if (!rotated1)
        {
            if (transform.position.x > 10)
            {
                transform.Rotate(rotate1, 0, 0);
                rotated1 = true;
            }
        }

        if (!rotated2)
        {
            if (transform.position.x > 17)
            {
                transform.Rotate(rotate2, 0, 0);
                rotated2 = true;
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
            OnPiranhaPassedAction?.Invoke();
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

