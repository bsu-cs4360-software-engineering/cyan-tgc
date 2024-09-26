using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CardObject : MonoBehaviour
{
    [SerializeField] public string cardName;
    private Vector3 oldScale = Vector3.one;
    public Vector3 newScale;
    public GameObject prefab;
    public GameObject[] field;
    // Start is called before the first frame update
    void Start()
    {
        cardName = ScriptableObject.CreateInstance<Cards>().cardName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver()
    {
        prefab.transform.localScale = newScale;
    }

    private void OnMouseExit()
    {
        prefab.transform.localScale = oldScale;
    }

    private void OnMouseDown()
    {
        if (prefab.transform.parent.parent.name.ToLower() != "field") {
            foreach (GameObject pos in field.Reverse())
            {
                if (pos.transform.childCount == 0)
                {
                    prefab.transform.parent = pos.transform;
                    prefab.transform.localPosition = pos.transform.localPosition;
                }
            }
        }
        else
        {
            DestroyClick();
        }
        
    }
    private void DestroyClick()
    {
        Destroy(prefab);
    }
    
}
