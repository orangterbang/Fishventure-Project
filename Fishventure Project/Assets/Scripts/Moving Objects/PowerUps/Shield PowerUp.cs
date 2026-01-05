using System;
using UnityEngine;

public class ShieldPowerUp : PowerUps
{
    public static event Action OnShieldPickUp;
    protected override void PickUp()
    {
        OnShieldPickUp?.Invoke();
        
        base.PickUp();
    }
}
