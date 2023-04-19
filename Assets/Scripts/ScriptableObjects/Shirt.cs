using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shirt", menuName = "Clothes/Shirt", order = 0)]
public class Shirt : ClothingItem
{
    public Sprite arm;
    public Sprite torso;
    
    private void Awake()
    {
        type = EClothing.Shirt;   
    }
}
