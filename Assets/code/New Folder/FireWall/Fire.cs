using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Gas;
    Animator anim;
    void Start()
    {
       anim = GetComponent<Animator>(); 
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Instantiate(Gas, transform.position, Gas.transform.rotation);
            Destroy(gameObject,0.1f);
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().Healthchange(2);
            collision.gameObject.GetComponent<hareket>().KnockBack();
        }
        else if (collision.gameObject.tag == "Waterball")
        {
            if (gameObject.transform.localScale.x < 6)
            {
                Instantiate(Gas, transform.position, Gas.transform.rotation);
                Destroy(gameObject);
            }
            gameObject.transform.localScale = new Vector3(9, 9, 9);
            StartCoroutine(Timer());
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.localScale = new Vector3(11, 11, 11);

    }
}
