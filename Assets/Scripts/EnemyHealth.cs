using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] GameObject screamSFX;

    bool isDead;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        if (isDead)
            return;

        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;

        if (hitPoints <= 0)
            Die();
    }

    void Die()
    {
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
        Instantiate(screamSFX, transform.position, Quaternion.identity);
    }
}
