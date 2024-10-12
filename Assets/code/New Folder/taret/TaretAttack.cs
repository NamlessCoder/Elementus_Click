using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TaretAttack : MonoBehaviour
{
    public GameObject Arrow;
    public Transform AttackPoint;

    public bool isPlayer;
    public float distance;
    public float AttackRate;
    public float AttackTime;




    void Start()
    {
       
    }

    void Update()
    {
        IsHere();
        if (isPlayer && Time.time >= AttackTime)
        {
         
            GameObject arrow = Instantiate(Arrow, AttackPoint.position, Arrow.transform.rotation);
            Vector3 origscale = arrow.transform.localScale;

            arrow.transform.localScale = new Vector3(
                origscale.x * -1,
                origscale.y,
                origscale.z
                );
            AttackTime = Time.time + AttackRate;
        }
      
    }
    public void IsHere()
    {
        RaycastHit2D hit = Physics2D.Raycast(AttackPoint.position, -transform.right, distance);
        if (hit == false)
        {
            isPlayer = false;
        }
        else if (hit.collider.gameObject.tag == "Player")
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }
     

    }
    private void OnDrawGizmos()
    {  

        Gizmos.DrawLine(AttackPoint.position, new Vector3(AttackPoint.position.x - distance, AttackPoint.position.y, AttackPoint.position.z));
    }
}
