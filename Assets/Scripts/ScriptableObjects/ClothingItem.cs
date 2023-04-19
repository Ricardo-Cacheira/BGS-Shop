using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base item fields
public class ClothingItem : ScriptableObject
{
    public EClothing type;
    public Sprite icon;
    public int price;
    public bool equipped;
}
