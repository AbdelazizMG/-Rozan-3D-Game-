using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class KingArthurStatus : MonoBehaviour
{
    public int damage = 50;
    public Animator anim;
    public NavMeshAgent agent;
    public GameObject Sphere;
    public AudioSource source;
    public float max_Health = 2000;
    public GameObject blood;
    public GameObject PowerUP;
    public GameObject PirateHealth;
    public Slider slider;
    public float current_Health;
    public GameObject HealthBall;
    
    public GameObject Text;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        source = GetComponent<AudioSource>();
        current_Health = max_Health;
        
        source.Stop();
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "AttackPoint")
        {
            current_Health -= damage;
            slider.value -= damage;
            anim.SetBool("Energy", false);
            anim.SetBool("Running", false);
            anim.SetBool("Attacking", false);
            anim.SetBool("Attacking2", false);
            anim.SetBool("idle", false);
            anim.SetBool("Running Backward", false);
            Instantiate(blood, transform.position, Quaternion.identity);
            source.Play();
            if (current_Health <= 0)
            {
                anim.SetBool("Dead", true);
                Instantiate(HealthBall, transform.position, Quaternion.identity);
                Instantiate(HealthBall, transform.position, Quaternion.identity);
                Instantiate(HealthBall, transform.position, Quaternion.identity);
                Instantiate(HealthBall, transform.position, Quaternion.identity);
                Instantiate(HealthBall, transform.position, Quaternion.identity);
                Instantiate(HealthBall, transform.position, Quaternion.identity);
                Instantiate(HealthBall, transform.position, Quaternion.identity);
                Instantiate(HealthBall, transform.position, Quaternion.identity);
                anim.SetBool("Dodge", false);
                anim.SetBool("Energy", false);
                anim.SetBool("Running", false);
                anim.SetBool("Attacking", false);
                anim.SetBool("Attacking2", false);
                anim.SetBool("idle", false);
                agent.enabled = false;
                Destroy(Text);
                Destroy(Sphere);
                Destroy(PirateHealth);
              
                Destroy(this.gameObject, 1f);
             

            }
        }
    }
    void QuitGame()
    {
        Application.Quit();
    }
   
}
