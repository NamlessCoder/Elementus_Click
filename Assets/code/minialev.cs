using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minialev : MonoBehaviour
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
            Destroy(gameObject, 0.1f);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<hareket>().rb.velocity = Vector2.zero;
            collision.gameObject.GetComponent<PlayerHealth>().Healthchange(1);
            collision.gameObject.GetComponent<hareket>().KnockBack();
        }
        else if (collision.gameObject.tag == "Waterball")
        {
            Destroy(collision.gameObject);
            Instantiate(Gas, transform.position, Gas.transform.rotation);
            Destroy(gameObject);
            StartCoroutine(Timer());
        }
        else if (collision.gameObject.tag == "Airball")
        {
            Destroy(collision.gameObject);
            gameObject.transform.localScale = new Vector3(11, 11, 11);
            StartCoroutine(Timer());
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.localScale = new Vector3(10, 10, 10);

    }
}
