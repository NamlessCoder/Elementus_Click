using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move1 : MonoBehaviour
{
    Rigidbody2D rb;

    Animator ar;
   
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;

    public GameObject canvas;
    public GameObject secim;
    public GameObject puzzle1;
    public GameObject puzzlesecim;



    public float speed;
  
    void Start()
    {

        speed = 200f;
       
        ar = GetComponent<Animator>();

        /*puzzle1 = GameObject.FindWithTag("puzzle1");
        puzzlesecim = GameObject.FindWithTag("puzzlesecim");*/

        canvas = GameObject.FindWithTag("UI");
        secim = GameObject.FindWithTag("secim");

        b1 = GameObject.FindWithTag("B1").GetComponent<Button>();
        b2 = GameObject.FindWithTag("B2").GetComponent<Button>();
        b3 = GameObject.FindWithTag("B3").GetComponent<Button>();
        b4 = GameObject.FindWithTag("B4").GetComponent<Button>();

        b1.onClick.AddListener(delegate { Secim(0); });
        b2.onClick.AddListener(delegate { Secim(1); });
        b3.onClick.AddListener(delegate { Secim(2); });
        b4.onClick.AddListener(delegate { Secim(3); });

        rb = GetComponent<Rigidbody2D>();

        secim.SetActive(false);
    }


    void Update()
    {
        ar.SetBool("run", speed != 0);

      
    }
    private void FixedUpdate()
    {
        
        if (this.GetComponent<hareket>().horizontal == 0 && this.GetComponent<hareket>().canMove)
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        }
        
        
    }
   
   /* private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "durak")
        {
            speed = 0f;
            secim.SetActive(true);
        }
    }
   */
   public void Duraktetik()
    {
        speed = 0f;
        
        secim.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.tag == "Healball")
        {
            speed = 0f;
            ar.SetTrigger("Heal");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "durak3")
        {
            Duraktetik();
            b1.gameObject.SetActive(false);
            b2.gameObject.SetActive(false);
            b3.gameObject.SetActive(false);
            b4.gameObject.SetActive(false);
            puzzle1.SetActive(true);
            puzzlesecim.SetActive(true);
            
        }
      
     
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.GetComponent<hareket>().canMove)
        {
            if (collision.gameObject.tag == "durak")
            {
                Duraktetik();
            }
            else if (collision.gameObject.tag == "durak2")
            {
                speed = 0f;
            }
            else if (collision.gameObject.tag == "durak12")
            {
                Duraktetik();
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "durak2")
        {
            speed = 230f;
        }
    }
    public void speedreset()
    {
        speed = 200f;
    }
    public void Secim(int i)
    {
        this.GetComponent<hareket>().canMove = false;
        this.GetComponent<SPELL>().timer = 2f;
        if (i == 0)
        {
            ar.SetTrigger("FireAttack");
            secim.SetActive(false);
        }
        else if (i == 1)
        {
            ar.SetTrigger("AirAttack");
            secim.SetActive(false);
        }
        else if (i == 2)
        {
            ar.SetTrigger("WaterAttack");
            secim.SetActive(false);
            
        }
        else if (i == 3)
        {
            ar.SetTrigger("LightingAttack");
            secim.SetActive(false);

        }
        speed = 200f;
    }
}
