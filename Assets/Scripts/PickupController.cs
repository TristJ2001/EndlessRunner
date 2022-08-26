
using UnityEngine;

public abstract class PickupController : MonoBehaviour
{
    protected float speed = 12f;
    
    public abstract void PickUp();

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp();
        }
    }

    public virtual void MovePickups()
    {
        if (transform.position.x < 27)
        {
           transform.Translate(Vector3.forward * (Time.deltaTime * speed));
           
        }
        else
        {
            DestroyPickup();
        }
    }

    public virtual void DestroyPickup()
    {
        Destroy(gameObject);
    }
}
