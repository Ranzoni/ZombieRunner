using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float changeRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] GameObject[] listGrowlSFX;
    [SerializeField] GameObject attackSFX;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;
    CapsuleCollider capsuleCollider;
    Transform target;
    GameObject growlSFXInstantiated;
    GameObject attackSFXInstantiated;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
            capsuleCollider.enabled = false;
            Destroy(growlSFXInstantiated);
            return;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
            EngageTarget();
        else if (distanceToTarget <= changeRange)
            isProvoked = true;
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }
    
    void EngageTarget()
    {
        FaceTarget();
        
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
            ChaseTarget();
        else
            AttackTarget();
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);

        if (attackSFXInstantiated == null)
        {
            Destroy(growlSFXInstantiated);
            attackSFXInstantiated = Instantiate(attackSFX, transform.position, Quaternion.identity);
        }
    }

    void FaceTarget()
    {
        var direction = (target.position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
    
    void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        Destroy(attackSFXInstantiated);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
        PlaySFX();
    }

    void PlaySFX()
    {
        if (growlSFXInstantiated != null)
            return;

        var random = Random.Range(0, listGrowlSFX.Length);
        var growlSFX = listGrowlSFX[random];
        growlSFXInstantiated = Instantiate(growlSFX, transform.position, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, changeRange);
    }
}
