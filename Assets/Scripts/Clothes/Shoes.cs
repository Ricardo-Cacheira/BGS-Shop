using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shoes", menuName = "Clothes/Shoes", order = 2)]
public class Shoes : ClothingItem
{
    public Sprite shoe;
    
    private void Awake()
    {
        type = EClothing.Shoes;   
    }
}
