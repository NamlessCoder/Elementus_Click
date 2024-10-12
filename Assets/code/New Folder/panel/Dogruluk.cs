using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Dogruluk : MonoBehaviour
{
    public int i1, i2, i3, i4, i5, i6, i;
    public List<GameObject> images;
   
    GameObject canvas;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindWithTag("secim");
        images.AddRange(GameObject.FindGameObjectsWithTag("images"));
        i = 0;
    }

   
    void Update()
    {
        Dogrumu();
        Puzzlebittimi();


    }

    public void Puzzlebittimi()
    {
        if (i == 6)
        {
            StartCoroutine(Timer());
        };
        
       
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
        canvas.SetActive(false);
        player.GetComponent<move1>().speedreset();



    }
    public void Dogrumu()
    {
        if (i1 + i2 == 3)
        {
            Renkler(i1,i2);
            
        }

        if (i3 + i4 == 7)
        {
            Renkler(i3,i4);
           
        }

        if (i5 + i6 == 11)
        {
           Renkler(i5, i6);
            
        }

       
    }
    
    public void Renkler(int k,int k1)
    {
        /*
         * bu yapý array GameObject[] images ile oluþturulmuþken kullanýldý
        foreach (var item in images)
        {
            if (item.name == "Image" + k || item.name == "Image" + k1)
            {
                item.GetComponent<Image>().color = Color.green;
                images.Remove(item);
                i++;

            }
        };
        */
        for (int t = 0; t < images.Count; t++)
        {
            if (images[t].name == "Image" + k || images[t].name == "Image" + k1)
            {
                images[t].GetComponent<Image>().color = Color.green;
                images.Remove(images[t]);
                i++;

            }
        }
    }
}
