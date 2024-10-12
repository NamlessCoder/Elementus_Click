using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ice : MonoBehaviour
{
    public GameObject water;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FireBall")
        {
            Instantiate(water,transform.position,water.transform.rotation);
            Destroy(gameObject);
            
        }
    }
}
