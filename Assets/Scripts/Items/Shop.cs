using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ClothingItem> items;
    [SerializeField] private ItemButton buttonPrefab;
    [SerializeField] private GridLayoutGroup grid;
    [SerializeField] private MiddleMenu middleMenu;
    [SerializeField] private InventoryManager inventory;

    void Start()
    {
        foreach (var item in items)
        {
            var button = (ItemButton)Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, grid.transform);
            button.Setup(item, true);
        }
    }

    private void OnEnable()
    {
        middleMenu.gameObject.SetActive(true);
        inventory.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        middleMenu.gameObject.SetActive(false);
        inventory.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
}
