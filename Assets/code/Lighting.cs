using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    public GameObject kapi;
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Waterball")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            kapi.GetComponent<Animator>().SetTrigger("kapiac");
            kapi.GetComponent<BoxCollider2D>().enabled = false;
            
        }
    }
  
}
