using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePrefabCont : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 12f;
    
    void FixedUpdate()
    {
        MoveTowardPlayer();
    }
    
    private void MoveTowardPlayer()
    {
        if (gameObject.transform.position.x < 27) 
        {
            gameObject.transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
