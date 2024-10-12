using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour
{
    public float Waterspeed;
    public Vector2 size;
    public GameObject Water;
    Rigidbody2D rb;

  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Waterspeed * transform.parent.localScale.x, rb.velocity.y);
     
    }

    
    void Update()
    {
       Destroy(Water, 10f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "FireWall")
        {
            Destroy(Water, 0.1f);
        }
        else if (collision.gameObject.tag == "Sea")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled =true;
            size = collision.gameObject.GetComponent<SpriteRenderer>().size;
            if (size.y < 0.50f)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().size = new Vector2(size.x, size.y + 0.2f);
            }
         
            Destroy(Water, 0.5f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(Water, 0.3f);
        }
    }



}
