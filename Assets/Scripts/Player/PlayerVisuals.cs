using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Expands on visuals for player specific needs
public class PlayerVisuals : Visuals
{
    [SerializeField] private PlayerInteractor interactor;
    [SerializeField] private InventoryManager inventory;
    [SerializeField] private Camera inventoryCamera;

    public Shirt Shirt {get => shirt;}
    public Pants Pants {get => pants;}
    public Shoes Shoes {get => shoes;}


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && !inventory.gameObject.activeInHierarchy)
            OpenInventory();

        if(Input.GetKeyDown(KeyCode.Escape) && inventory.gameObject.activeInHierarchy)
            CloseInventory();
    }

    private void OpenInventory()
    {
        inventory.gameObject.SetActive(true);
        inventoryCamera.gameObject.SetActive(true);
        interactor.enabled = false;
        ItemButton.itemEquip += EquipClothing;
    }

    private void CloseInventory()
    {
        inventory.gameObject.SetActive(false);
        inventoryCamera.gameObject.SetActive(false);
        interactor.enabled = true;
        ItemButton.itemEquip -= EquipClothing;
    }
}
