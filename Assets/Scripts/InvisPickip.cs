using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisPickip : PickupController
{
    public delegate void InvisPickupAction();

    public static event InvisPickupAction OnInvisPickupActivated;
    void Update()
    {
        MovePickups();
    }

    public override void PickUp()
    {
        OnInvisPickupActivated?.Invoke();
        DestroyPickup();
    }
}
