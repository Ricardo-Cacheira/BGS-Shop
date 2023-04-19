using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<ClothingItem> items;
    [Space]
    [SerializeField] private ItemButton buttonPrefab;
    [SerializeField] private GridLayoutGroup grid;
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private PlayerVisuals visuals;

    private int coins = 50;

    private void OnEnable()
    {
        MiddleMenu.Buy += OnBuy;
        MiddleMenu.Sell += OnSell;
    }

    private void OnDisable()
    {
        MiddleMenu.Buy -= OnBuy;
        MiddleMenu.Sell -= OnSell;
    }

    void Start()
    {
        money.text = coins.ToString();
        //Create Buttons with starting inventory items
        foreach (var item in items)
        {
            var button = (ItemButton)Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, grid.transform);
            button.Setup(item, false);
        }
    }

    //handle UI and player coins/inventory after buying an Item
    private void OnBuy(ClothingItem item)
    {
        if(item.price <= coins)
        {
            coins -= item.price;
            money.text = coins.ToString();
            items.Add(item);
            var button = (ItemButton)Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, grid.transform);
            button.Setup(item, false);
        }
    }

    //handle UI and player coins/inventory after selling an Item
    private void OnSell(ClothingItem item)
    {
        coins += item.price;
        money.text = coins.ToString();
        foreach (ItemButton child in grid.GetComponentsInChildren<ItemButton>())
        {
            if(child.Item.name == item.name)
            {
                items.RemoveAt(child.transform.GetSiblingIndex());
                Destroy(child.gameObject);
                break;
            }
        }

        switch (item.type)
        {
            case EClothing.Shirt:
            if(visuals.Shirt.name == item.name)
                visuals.UnequipClothing(item.type);
            break;

            case EClothing.Pants:
            if(visuals.Pants.name == item.name)
                visuals.UnequipClothing(item.type);
            break;

            case EClothing.Shoes:
            if(visuals.Shoes.name == item.name)
                visuals.UnequipClothing(item.type);
            break;

            default: break;
        }
    }
}
