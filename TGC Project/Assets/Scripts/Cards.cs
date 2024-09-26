using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] 

public class Cards : ScriptableObject
{
    public string cardName;
    public enum cardType
    {
        Spell,
        Weapon,
        Armor,
        Potion
    }
    [SerializeField] private cardType _cardType;

    public enum effect
    {
        None,
        Fire,
        Ice,
        Shock,
        Grease,
        Toxic
    }
    [SerializeField] private effect _effect;

    public int damage = 0;


}
