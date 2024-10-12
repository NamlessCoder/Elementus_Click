using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBall : MonoBehaviour
{
    Rigidbody2D rb;
    public float AirSpeed;
    GameObject obje;
    Animator ar;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ar = GetComponent<Animator>();
        
       
    }
    void Start()
    {
       
        rb.velocity = new Vector2(AirSpeed * transform.localScale.x, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FireWall")
        {
            obje = collision.gameObject;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<Transform>().localScale = new Vector3(15,15,15);
            StartCoroutine(Timer());
            
            
        }
        else if (collision.gameObject.tag == "durak")
        {
            Destroy(collision.gameObject);
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        obje.gameObject.GetComponent<Transform>().localScale = new Vector3(11, 11, 11);
        Destroy(gameObject);
    }
}
