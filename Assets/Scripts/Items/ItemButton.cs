using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public static Action<ClothingItem, bool> itemClicked;
    public static Action<ClothingItem> itemEquip;

    [SerializeField] private Image icon;
    private Button button;
    private ClothingItem item;
    private bool isShopItem;

    public ClothingItem Item {get => item;}

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void OnClick()
    {
        itemClicked?.Invoke(item, isShopItem);
        itemEquip?.Invoke(item);
    }

    public void Setup(ClothingItem clothingItem, bool shopItem)
    {
        item = clothingItem;
        icon.sprite = item.icon;
        isShopItem = shopItem;
    }
}
