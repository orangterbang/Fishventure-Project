using System;
using UnityEngine;

public class SpeedPowerUp : PowerUps
{
    public static event Action OnSpeedPickUp;
    protected override void PickUp()
    {
        OnSpeedPickUp?.Invoke();
        
        base.PickUp();
    }
}
