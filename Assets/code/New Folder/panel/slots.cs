using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86;

public class slots : MonoBehaviour,IDropHandler
{
    Dogruluk dogru;
    public void OnDrop(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<dragdrop>().istrue == true)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;

            if ((eventData.pointerDrag.name == "ates_s" || eventData.pointerDrag.name == "sutopu_s") && (this.name == "Image1" || this.name == "Image2"))
            {
                if (this.name == "Image1")
                {
                    dogru.i1 = 1;
                }
                else if (this.name == "Image2")
                {
                    dogru.i2 = 2;
                }
                eventData.pointerDrag.GetComponent<dragdrop>().istrue = false;
            }
            else if ((eventData.pointerDrag.name == "atestopu_s" || eventData.pointerDrag.name == "buz_s") && (this.name == "Image3" || this.name == "Image4"))
            {
                if (this.name == "Image3")
                {
                    dogru.i3 = 3;
                }
                else if (this.name == "Image4")
                {
                    dogru.i4 = 4;
                }
                eventData.pointerDrag.GetComponent<dragdrop>().istrue = false;
            }
            else if ((eventData.pointerDrag.name == "hava_s" || eventData.pointerDrag.name == "su_s (1)") && (this.name == "Image5" || this.name == "Image6"))
            {
                if (this.name == "Image5")
                {
                    dogru.i5 = 5;
                }
                else if (this.name == "Image6")
                {
                    dogru.i6 = 6;
                }
                eventData.pointerDrag.GetComponent<dragdrop>().istrue = false;
            }

        }
        
        

    }
    

    void Start()
    {
        dogru = GetComponentInParent<Dogruluk>();
    
        
    }

    void Update()
    {
       
    }
   
}
