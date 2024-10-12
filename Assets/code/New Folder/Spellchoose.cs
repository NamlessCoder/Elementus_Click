using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Spellchoose : MonoBehaviour
{
    public Image Fire;
    public Image Air;
    public Image Water;
    void Start()
    {
        
    }

    // Update is called once per 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Fire.color = new Color32(255,49,0,255);
            Air.color = new Color32(255, 255, 255, 255);
            Water.color = new Color32(255, 255, 255, 255);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Air.color = new Color32(0,253,155,255);
            Fire.color = new Color32(255, 255, 255, 255);
            Water.color = new Color32(255, 255, 255, 255);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Water.color = new Color32(17,25,245,255);
            Fire.color = new Color32(255, 255, 255, 255);
            Air.color = new Color32(255, 255, 255, 255);
        }
    }
}
