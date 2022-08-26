using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1Cont : MonoBehaviour
{
    public delegate void OnLastSnowballSpawned();
    public static event OnLastSnowballSpawned OnLastSnowballSpawnedAction;
    
    [SerializeField] private GameObject projectile;
    [SerializeField] private int spawnRate = 20;
    
    private int i;
    private int j;
    private int t;
    private float playerPos;

    void FixedUpdate()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        
        SetTrans(playerPos);
        
        if (j == spawnRate)
        {
            if (t < 50)
            {
                SFXManager._instance.PlaySound("Laser_Shoot");
                SpawnProj();
                j = 0;
            }
            else if (t == 50)
            {
                SpawnProj();
                Debug.Log("Last snowball");
                OnLastSnowballSpawnedAction?.Invoke();
                t++;
            }
        }
        else
        {
            j++;
        }
    }
    
    void SetTrans(float n)
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, transform.position.y, n);
    }

    void SpawnProj()
    {
        Vector3 currentPos = new Vector3(transform.position.x, 0.5f, transform.position.z);
        
        GameObject projClone = Instantiate(projectile, currentPos, Quaternion.Euler(0, 0, 0));
        t++;
    }
}
