using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStatus : MonoBehaviour
{

    
    public int damage=25;

    public Slider slider;

    public GameObject Sphere;
    public int maxhealth = 50;
    public GameObject blood;
    public Animator anim;
    public AudioSource audiosource;
    public int currenthealth;
    public NavMeshAgent agent;
    public GameObject HealthBall;
    public Text score;

    public float newscore = 0;


    void Start()
    {
        anim = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        currenthealth = maxhealth;
        
        audiosource.Stop();
        

    }
    public void OnTriggerEnter(Collider collider)
    {
        
        if(collider.gameObject.tag == "AttackPoint" )
        {
            
            audiosource.Play();
            currenthealth -= damage;
            slider.value -= damage;
            Instantiate(blood, transform.position, Quaternion.identity);
            if (currenthealth <= 0)
            {
            
                Instantiate(HealthBall, transform.position, Quaternion.identity);
                anim.SetBool("Dead", true);
                anim.SetBool("idle", false);
                anim.SetBool("Running", false);
                anim.SetBool("Attacking", false);
                anim.SetBool("Attacking2", false);
                anim.SetBool("Attacking3", false);
                
                Destroy(Sphere);
                Destroy(this.gameObject,1.5f);
             
               
                
            }
        }  
    }



    private void LateUpdate()
    {
      
        
            score.text = "Time: " + newscore.ToString("0");
            newscore+= 0.05f;
        
      
    }

}
