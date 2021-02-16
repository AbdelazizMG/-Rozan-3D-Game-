using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KingArthur : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    public AudioClip[] clips;

    public AudioSource audioSource;
    NavMeshAgent agent;
    public int lookRaduis = 100;
    public Animator animator;
    int clips_orders;
    int voice_order;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
       
    }

    void Update()
    {

        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= lookRaduis)
        {
            agent.SetDestination(player.position);
            animator.SetBool("Energy", true);
            animator.SetBool("Running", true);
            animator.SetBool("Attacking2", true);
            animator.SetBool("Attacking", false);
            animator.SetBool("idle", false);

           
            if (distance <= agent.stoppingDistance)  //distnace<=agent.stoppingDistance
            {
                Attack();
                FaceTarget();
            }

        }
    }
    void FaceTarget()
    {

        Vector3 direction = player.position - transform.position;
        if (direction.x !=0 && direction.z != 0)
        {

            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        } 
        
        
    }
    void Attack()
    {
        animator.SetBool("idle", false);
        animator.SetBool("Running", false);
        animator.SetBool("Attacking", true);
        animator.SetBool("Energy", true);
        voice_order = Random.Range(0, 300);
        clips_orders = Random.Range(0, 4);
        if(voice_order==220 || voice_order == 22 || voice_order == 128 || voice_order == 255 || voice_order == 1 || voice_order == 120 || voice_order == 12 || voice_order == 200)
        {
            audioSource.PlayOneShot(clips[clips_orders]);
        }
        
        
       
    }
    


            
          
        
   
}
