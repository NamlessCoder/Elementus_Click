using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SPELL : MonoBehaviour
{
    public GameObject Fireball;
    public GameObject Airball;
    public GameObject Waterball;
    public GameObject StoneWallSpawn;
    public Transform rangeattack;
    public GameObject Lighting;

    Rigidbody2D rb;
    Animator ar;
    hareket ph;
    PlayerHealth phealt;

    public float timer;
    public float timerSet;

    public bool dead;


    public int CurrentPower;
    void Start()
    {
        ar = GetComponent<Animator>();
        ph = GetComponent<hareket>();
        phealt = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();

        CurrentPower = 4;
        timerSet = 1;
    }

    // Update is called once per frame
    void Update()
    {
        KeyBinds();
       
        if(!ph.OnWall() && ph.IsGrounded() )
        {
            StoneWallTriger();
            SpellSkill();

            if (phealt.Health > 0 && phealt.Health < 6 && ph.canMove)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {

                    HealMe();
                }
            }
        }

        if (!ph.canMove)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && !dead)
        {
            ph.ControlMove(true);
            timer = timerSet;
        }

    }
    public void isdead(bool d)
    {
        if (d == true)
        {
            dead = true;
        }
        else
        {
            dead = false;
        }
    }
    public void KeyBinds()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentPower = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentPower = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentPower = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CurrentPower = 3;
        }


    }
    public void SpellSkill()
    {
        switch (CurrentPower)
        {
            case 0:
                Firemove();
                break;

            case 1:
                Airmove();
                break;

            case 2:
                Watermove();
                break;


            case 3:
                Lightmove();
                break;

            case 4:
               
                break;



        }
    }

    public void HealMe()
    {
        timer = 1.5f;
        rb.velocity = Vector2.zero;
        ph.ControlMove(false);
        ar.SetTrigger("Heal");
    }
    public void Firemove()
    {
        if (Input.GetMouseButtonDown(0) && ph.canMove)
        {
            rb.velocity = Vector2.zero;
            ph.ControlMove(false);
            ar.SetTrigger("FireAttack");
        
        }


    }


    public void Airmove()
    {
        if (Input.GetMouseButtonDown(0) && ph.canMove)
        {
            timer = 1.5f;
            rb.velocity = Vector2.zero;
            ph.ControlMove(false);
            ar.SetTrigger("AirAttack");


        }
       

    }

    public void Watermove()
    {
        if (Input.GetMouseButtonDown(0) && ph.canMove)
        {
            timer = 1.5f;
            rb.velocity = Vector2.zero;
            ph.ControlMove(false);
            ar.SetTrigger("WaterAttack");


        }
    }
    public void Lightmove()
    {
        if (Input.GetMouseButtonDown(0) && ph.canMove)
        {
            timer = 1.5f;
            rb.velocity = Vector2.zero;
            ph.ControlMove(false);
            ar.SetTrigger("LightingAttack");


        }
    }

    public void WaterAttack()
    {
        GameObject Water = Instantiate(Waterball, rangeattack.position, Waterball.transform.rotation);
        Vector3 origscale = Water.transform.localScale;

        Water.transform.localScale = new Vector3(
            origscale.x * transform.localScale.x > 0 ? 1 : -1,
            origscale.y,
            origscale.z
            );
    }

    public void AirAttack()
    {

        GameObject Air = Instantiate(Airball, rangeattack.position, Airball.transform.rotation);
        Vector3 origscale = Air.transform.localScale;

        Air.transform.localScale = new Vector3(
            origscale.x * transform.localScale.x > 0 ? 5 : -5,
            origscale.y,
            origscale.z
            );
    }

    public void FireAttack()
    {
        GameObject fire = Instantiate(Fireball, rangeattack.position, Fireball.transform.rotation);
        Vector3 origscale = fire.transform.localScale;

        fire.transform.localScale = new Vector3(
            origscale.x * transform.localScale.x > 0 ? 10 : -10,
            origscale.y,
            origscale.z
            );
       
    }
    public void LightingAttack()
    {
        GameObject lighting = Instantiate(Lighting, rangeattack.position, Lighting.transform.rotation);
        Vector3 origscale = lighting.transform.localScale;

        lighting.transform.localScale = new Vector3(
            origscale.x * transform.localScale.x > 0 ? 1 : -1,
            origscale.y,
            origscale.z
            );

    }


    public void StoneWallTriger()
    {
        
        if (Input.GetKeyDown(KeyCode.S) && ph.canMove)
        {
            timer = 1.5f;
            rb.velocity = Vector2.zero;
            ph.ControlMove(false);
            ar.SetTrigger("StoneWall");

          
        }
       
    }
    public void StoneWallOn()
    {
        StoneWallSpawn.SetActive(true);
    }
    public void StoneWallOf()
    {
        StoneWallSpawn.SetActive(false);
    }
}
