using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;

    void Start()
    {
        target = FindAnyObjectByType<PlayerHealth>();
    }
    
    public void AttackHitEvent()
    {
        if (target == null)
            return;

        target.TakeDamage(damage);
        FindObjectOfType<PlayerHurt>().PlaySoundEffect();
    }
}
