using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class PlayerHealth : MonoBehaviour
{
    public Image HealtBar;
    Animator anim;
   

    public float Health = 6;
    public int HalfCounter;
    void Start()
    {
        anim = GetComponent<Animator>();
      
    }

   
    void Update()
    {
        if(Health <= 0)
        {
            anim.SetBool("Death",true);
            gameObject.GetComponentInParent<hareket>().ControlMove(false);
            gameObject.GetComponent<SPELL>().isdead(true);
          
            
            
        }
    
    }
  
    public void Healthchange(float HealthchangeValue)
    {
        if (HealthchangeValue > 0 && (HealthchangeValue % 2 == 1 || HealthchangeValue == 1))
        {

            if (Health % 2 == 0)
            {
                HalfCounter = 0;
            }
            else
            {
                HalfCounter = 2;
            }
            Health -= HealthchangeValue;

            HealthchangeValue = (3.5f * HealthchangeValue + HalfCounter) / 25;
            HealtBar.fillAmount -= HealthchangeValue;
        }
        else if (HealthchangeValue > 0 && HealthchangeValue % 2 == 0) {
           
            HalfCounter = 2;
            Health -= HealthchangeValue;

            HealthchangeValue = (3.5f * HealthchangeValue + HalfCounter) / 25;
            HealtBar.fillAmount -= HealthchangeValue;
        }

        else
        {
            Health -= HealthchangeValue;
            if (Health % 2 == 0)
            {
                HalfCounter = 0;
            }
            else
            {
                HalfCounter = 2;
            }

            HealthchangeValue = (3.5f * HealthchangeValue - HalfCounter) / 25;
            HealtBar.fillAmount -= HealthchangeValue;
        }

        
    }
}
