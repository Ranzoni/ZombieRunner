using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        
        var displayDamage = FindObjectOfType<DisplayDamage>();
        displayDamage.Display();
        
        if (hitPoints <= 0)
            GetComponent<DeathHandler>().HandleDeath();
    }
}
