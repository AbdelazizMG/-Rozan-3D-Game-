using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    public int damage = 20;
    public float currenthealth;
    public Slider healthbar;
    public Animator anim;
    public GameObject Blood;
    public AudioSource audiosource2;
    public int max_Health = 10000;
    public GameObject sphere;
    public AudioClip[] clips;

    PauseMenu menu;

    
  

    void Start()
    {
        currenthealth = max_Health;
        anim = GetComponent<Animator>();
        audiosource2 = GetComponent<AudioSource>();
        audiosource2.Stop();
        Cursor.visible = false;
        menu = GetComponent<PauseMenu>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "AttackPointEnemy" )
        {
            audiosource2.volume = 0.5f;
            audiosource2.PlayOneShot(clips[0]);
            healthbar.value -= damage;
            currenthealth -= damage;
           
            Instantiate(Blood, transform.position, Quaternion.identity);
            if (currenthealth <= 0)
            {
                
                anim.SetBool("Dead", true);
                if (menu)
                {
                    menu.pause();
                }
                    Invoke("RestartGame", 8f);
                
            }
            
        }
        if (collider.gameObject.tag == "AttackPointKingArthur")
        {
            audiosource2.volume = 0.5f;
            audiosource2.PlayOneShot(clips[0]);
            healthbar.value -= 85;
            currenthealth -= 85;
            Instantiate(Blood, transform.position, Quaternion.identity);
            if (currenthealth <= 0)
            {
               
                anim.SetBool("Dead", true);
                if (menu)
                {
                    menu.pause();
                }
                
              
                
                
              
            }
        }
            if (collider.gameObject.tag=="HP" && healthbar.value != max_Health)
        {
            audiosource2.volume = 1;
            audiosource2.PlayOneShot(clips[1]);
            healthbar.value += 55;
            currenthealth += 55;
            Destroy(collider.gameObject);

        }
    }

   public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }



}
