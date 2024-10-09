using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CardObject : MonoBehaviour
{
    [SerializeField] public string cardName;
    private Vector3 oldScale = Vector3.one;
    public Vector3 newScale;
    public GameObject prefab;
    public GameObject field;
    private bool pickedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        cardName = ScriptableObject.CreateInstance<Cards>().cardName;
        Debug.Log(field.transform.GetChild(0).localPosition);

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
            for (int x = 0; x < field.transform.childCount; x++)
            {
                if (field.transform.GetChild(x).transform.childCount == 0)
                {
                    prefab.transform.parent = field.transform.GetChild(x).transform;
                    prefab.transform.localPosition = Vector3.zero;
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
