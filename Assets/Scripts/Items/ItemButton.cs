using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private Image icon;

    private ClothingItem item;

    public void OnClick()
    {
        
    }

    public void Setup(ClothingItem clothingItem)
    {
        item = clothingItem;
        icon.sprite = item.icon;
    }
}
