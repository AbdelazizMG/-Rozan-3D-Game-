using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed = 40f;
    public float gravity = 6f;
    public float rotSpeed = 80f;
    public float jump = 8f;
    public Transform model;

    public AudioSource Source1;


    Animator anim;
    int isWalkingHash;
    int isAttacking1Hash;
    int isAttacking2Hash;

    public bool isAnimating = false;

    public AudioClip[] clips;
    int clip_order;

    public CharacterController controller;
    Vector3 moveDirection = Vector3.zero;
    
    
    void Start()
    {
        Source1 = GetComponent<AudioSource>();
        controller.GetComponent<CharacterController>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isAttacking1Hash = Animator.StringToHash("isAttacking1 (Q)");
        isAttacking2Hash = Animator.StringToHash("isAttacking2 (E)");
        anim = GetComponent<Animator>();
       
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float dodge = Input.GetAxis("Dodge");
        float attack1 = Input.GetAxis("Fire1");
        float attack2 = Input.GetAxis("Fire2");

         moveDirection = transform.forward * vertical * speed;
         //moveDirection = new Vector3(0f, 0f, vertical).normalized * speed ;

        if (controller.isGrounded)
        {

            //moveDirection = transform.TransformDirection(moveDirection);
            
            if(vertical > 0)
            {
                anim.SetBool(isWalkingHash,true);
             
            }
            else { anim.SetBool(isWalkingHash, false); }


            if (vertical < 0)
            {
                anim.SetBool("isReturning", true);
                anim.SetBool(isAttacking2Hash, false);


            }  
            else { anim.SetBool("isReturning", false); }
         
            if (attack1 >0) 
            {
                
                anim.SetBool(isAttacking2Hash, true);
                clip_order = Random.Range(0, 1000);
                if (clip_order < 50)
                {
                    Source1.PlayOneShot(clips[2]);
                }

            }
            else
            {
                 anim.SetBool(isAttacking2Hash, false);
                
               
            }
            if (attack2 >0 )
            {

                anim.SetBool(isAttacking1Hash, true);
                isAnimating = true;
                clip_order = Random.Range(0, 1000);
                if (clip_order > 900)
                {
                    Source1.PlayOneShot(clips[2]);
                }


            }
            else
            {
                anim.SetBool(isAttacking1Hash, false);
                isAnimating = false;
                
            }
            if(dodge>0)
            {
                anim.SetBool("dodge", true);
                transform.position = model.position;
                
            }
            else
            {
                anim.SetBool("dodge", false);
            }

            
        }
       
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
   
}
