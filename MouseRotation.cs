using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public float speedH = 0.5f;
    public float speedV = 0.5f;

    private float yaw = 0.0f;
    

    public Transform player;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= speedV * Input.GetAxis("Mouse Y");

        yaw = Mathf.Clamp(yaw, -540f, 540f);

        //pitch = Mathf.Clamp(pitch, -60f, 90f);
        player.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw ,0.0f);
        
    }
}
