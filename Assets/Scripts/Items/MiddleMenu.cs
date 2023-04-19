using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiddleMenu : MonoBehaviour
{
    [SerializeField] private Image item;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI buttonText;

    private ClothingItem clothingItem;
    private bool isShopItem;

    private void OnEnable()
    {
        item.sprite = null;
        item.gameObject.SetActive(false);
        itemName.text = "";
        price.text = "0";
        button.enabled = false;

        ItemButton.itemClicked += UpdateUI;
    }

    private void OnDisable()
    {
        ItemButton.itemClicked -= UpdateUI;
    }
    
    private void UpdateUI(ClothingItem clothing, bool shopItem)
    {
        clothingItem = clothing;

        item.sprite = clothingItem.icon;
        item.gameObject.SetActive(true);
        itemName.text = clothingItem.name;
        price.text = clothingItem.price.ToString();
        buttonText.text = shopItem ? "Buy" : "Sell";
        button.enabled = true;

        isShopItem = shopItem;
    }

    public void OnClick()
    {
        
    }
}
