using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;
        
        var ammo = FindObjectOfType<Ammo>();
        ammo.IncreaseCurrentAmmo(ammoType, ammoAmount);
        Destroy(gameObject);
    }
}
