using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pants", menuName = "Clothes/Pants", order = 1)]
public class Pants : ClothingItem
{
    public Sprite leg;
    public Sprite waist;

    private void Awake()
    {
        type = EClothing.Pants;   
    }
}
