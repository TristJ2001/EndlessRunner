using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ELCont : PickupController
{
    public delegate void ExtraLifeAction();

    public static event ExtraLifeAction OnExtraLifeActivated;
    void Update()
    {
        MovePickups();
    }

    public override void PickUp()
    {
        OnExtraLifeActivated?.Invoke();
        DestroyPickup();
    }
}
