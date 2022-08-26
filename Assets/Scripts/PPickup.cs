using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPickup : PickupController
{
    public delegate void PointsPickupAction();

    public static event PointsPickupAction OnPointsPickupActivated;
    
    void Update()
    {
        MovePickups();
    }
    
    public override void PickUp()
    {
        OnPointsPickupActivated?.Invoke();
        DestroyPickup();
    }
}
