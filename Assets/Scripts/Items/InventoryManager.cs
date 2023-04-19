using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<ClothingItem> items;
    [SerializeField] private ItemButton buttonPrefab;
    [SerializeField] private GridLayoutGroup grid;

    void Start()
    {
        foreach (var item in items)
        {
            var button = (ItemButton)Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity);
            button.transform.parent = grid.transform;
            button.Setup(item);
        }
    }

    void Update()
    {
        
    }
}