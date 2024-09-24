using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrawBehavior : MonoBehaviour
{
    public CardScriptHandler cardScriptHandler;

    public Button Draw;
    private GameObject CardPos1;

    
    // Start is called before the first frame update
    void Start()
    {
        Button btn = Draw.GetComponent<Button>();
        btn.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onClick()
    {
        CardPos1 = GameObject.Find("CardPos1");
        if (CardPos1.transform.childCount < 1)
        {
            CardPos1.Add(Card);
        }
        
    }
}
