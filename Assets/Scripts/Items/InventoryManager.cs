using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<ClothingItem> items;
    [Space]
    [SerializeField] private ClothingItem currentShirt;
    [SerializeField] private ClothingItem currentPants;
    [SerializeField] private ClothingItem currentShoes;
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
        foreach (var item in items)
        {
            var button = (ItemButton)Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity);
            button.transform.parent = grid.transform;
            button.Setup(item, false);
        }
    }

    private void OnBuy(ClothingItem item)
    {
        if(item.price <= coins)
        {
            coins -= item.price;
            money.text = coins.ToString();
            items.Add(item);
            var button = (ItemButton)Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity);
            button.transform.parent = grid.transform;
            button.Setup(item, false);
        }
    }

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
            if(currentShirt.name == item.name)
            {
                visuals.UnequipClothing(item.type);
                currentShirt = null;
            }
            break;

            case EClothing.Pants:
            if(currentPants.name == item.name)
            {
                visuals.UnequipClothing(item.type);
                currentPants = null;
            }
            break;

            case EClothing.Shoes:
            if(currentShoes.name == item.name)
            {
                visuals.UnequipClothing(item.type);
                currentShoes = null;
            }
            break;

            default: break;
        }
    }
}
