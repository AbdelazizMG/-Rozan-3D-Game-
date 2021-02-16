using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    bool paused = false;
    bool hidden = false;


  
  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!paused)
            {
                pause();
            }

            else
            {
                unpaused();
            }
            
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            if (!hidden)
            {
                object2.SetActive(false);
                hidden = true;
            }
            else
            {
                object2.SetActive(true);
                hidden = false;
            }
           
        }
    }
    public void pause()
    {
        Cursor.visible = true;
        object1.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
    }
    public void unpaused()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        object1.SetActive(false);
        paused = false;
    }
}
