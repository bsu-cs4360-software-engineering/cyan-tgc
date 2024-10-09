using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DrawBehavior : MonoBehaviour
{
    public Button Draw;
    public GameObject hand;
    public GameObject cardBase;
    void Start()
    {
        
        Button draw = Draw.GetComponent<Button>();
        draw.onClick.AddListener(DrawCard);

    }

    void DrawCard()
    {
        for (int x = 0; x < hand.transform.childCount; x++) 
        { 
            if(hand.transform.GetChild(x).childCount < 1)
            {
                Instantiate(cardBase,hand.transform.GetChild(x));
                break;
            }
        }
    }
    
}
