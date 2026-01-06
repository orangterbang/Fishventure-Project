using System;
using UnityEngine;

public class UltimatePowerUp : PowerUps
{
    public static event Action OnUltimatePickUp;

    protected override void PickUp()
    {
        OnUltimatePickUp?.Invoke();
        
        base.PickUp();
    }
}
