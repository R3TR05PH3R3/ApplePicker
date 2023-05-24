using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "Scriptable Objects/New shop Item", order = 1)]
public class ShopItem : ScriptableObject
{
    public string title;
    public string description;
    public int cost;
    public bool isPurchased = false;
}
