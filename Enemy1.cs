using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{
 
    public Transform player;


    
    NavMeshAgent agent;
    public int lookRaduis = 70;
    public Animator animator;
    
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
    
    }


    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= lookRaduis)
        {

              
                agent.SetDestination(player.position);
                animator.SetBool("idle", false);
                animator.SetBool("Running", true);
                animator.SetBool("Attacking", false);
                animator.SetBool("Attacking2", false);
                animator.SetBool("Attacking3", false);

            if (distance <= agent.stoppingDistance)  //distnace<=agent.stoppingDistance
                {
                    Attack();
                    FaceTarget();
                }
      
        }
        else
        {
            animator.SetBool("idle", true);
            animator.SetBool("Running", false);
            animator.SetBool("Attacking", false);
            animator.SetBool("Attacking2", false);
            animator.SetBool("Attacking3", false);

        }
    }

    void FaceTarget()
    {
        Vector3 direction = player.position - transform.position;
        if(direction.x !=0 && direction.z !=0)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
       
    }
    void Attack()
    {
        
        animator.SetBool("Running", false);
        animator.SetBool("Attacking", true);
        animator.SetBool("Attacking2", true);
        animator.SetBool("Attacking3", true);
        

    }
}
