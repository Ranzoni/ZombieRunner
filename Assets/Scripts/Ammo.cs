using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [Serializable]
    class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        var ammoSlot = GetAmmoSlot(ammoType);
        if (ammoSlot == null)
            return 0;
        
        return ammoSlot.ammoAmount;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        var ammoSlot = GetAmmoSlot(ammoType);
        if (ammoSlot == null)
            return;

        ammoSlot.ammoAmount += ammoAmount;
    }
    
    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        var ammoSlot = GetAmmoSlot(ammoType);
        if (ammoSlot == null)
            return;

        ammoSlot.ammoAmount--;
    }

    AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (var slot in ammoSlots)
            if (slot.ammoType == ammoType)
                return slot;

        return null;
    }
}
