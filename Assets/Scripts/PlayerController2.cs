using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private int speed;
    private int saveSpeed;

    private int i;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.z < -4)
            {
                return;
            }
            transform.Translate(Vector3.back * (Time.deltaTime * speed));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.z > 4)
            {
                return;
            }
            transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if(i == 0)
            {
                SFXManager._instance.PlaySound("Jump");
                i++;
            }
            
            transform.Translate(Vector3.up * (Time.deltaTime * speed));
            if (transform.position.y > 8)
            {
                transform.Translate(Vector3.down * (Time.deltaTime * speed));
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            i = 0;
        }
    }
}
