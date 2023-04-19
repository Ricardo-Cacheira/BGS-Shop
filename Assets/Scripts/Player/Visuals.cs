using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EClothing
{
    Shirt,
    Pants,
    Shoes    
}

public class Visuals : MonoBehaviour
{
    [Header("Current Clothes")]
    [SerializeField] protected Shirt shirt;
    [SerializeField] protected Pants pants;
    [SerializeField] protected Shoes shoes;

    [Header("New Item (For Testing)")]
    public ClothingItem item;

    [Header("Scene Objects")]
    [SerializeField] private SpriteRenderer shirtTorso;
    [SerializeField] private SpriteRenderer shirtSleeveRight;
    [SerializeField] private SpriteRenderer shirtSleeveLeft;

    [SerializeField] private SpriteRenderer pantsWaist;
    [SerializeField] private SpriteRenderer pantLegRight;
    [SerializeField] private SpriteRenderer pantLegLeft;
    
    [SerializeField] private SpriteRenderer shoeRight;
    [SerializeField] private SpriteRenderer shoeLeft;
    [SerializeField] private SpriteRenderer footRight;
    [SerializeField] private SpriteRenderer footLeft;

    //Testing in Editor
    private void OnValidate()
    {
        EquipClothing(item);
    }

    protected void EquipClothing(ClothingItem newItem)
    {
        if(newItem == null)
            return;

        switch (newItem.type)
        {
            case EClothing.Shirt:
            if(shirt != null && newItem.name == shirt.name)
            {
                UnequipClothing(newItem.type);
                break;
            }
            shirt = (Shirt)newItem;
            shirtTorso.sprite = shirt.torso;
            shirtSleeveRight.sprite = shirtSleeveLeft.sprite = shirt.arm;
            break;

            case EClothing.Pants:
            if(pants != null && newItem.name == pants.name)
            {
                UnequipClothing(newItem.type);
                break;
            }
            pants = (Pants)newItem;
            pantsWaist.sprite = pants.waist;
            pantLegRight.sprite = pantLegLeft.sprite = pants.leg;
            break;

            case EClothing.Shoes:
            if(shoes != null && newItem.name == shoes.name)
            {
                UnequipClothing(newItem.type);
                break;
            }
            shoes = (Shoes)newItem;
            shoeRight.sprite = shoeLeft.sprite = shoes.shoe;
            footRight.gameObject.SetActive(false);
            footLeft.gameObject.SetActive(false);
            break;

            default: break;
        }

        item = null;
    }

    public void UnequipClothing(EClothing type)
    {
        switch (type)
        {
            case EClothing.Shirt:
            shirt = null;
            shirtTorso.sprite = null;
            shirtSleeveRight.sprite = shirtSleeveLeft.sprite = null;
            break;

            case EClothing.Pants:
            pants = null;
            pantsWaist.sprite = null;
            pantLegRight.sprite = pantLegLeft.sprite = null;
            break;

            case EClothing.Shoes:
            shoes = null;
            shoeRight.sprite = shoeLeft.sprite = null;
            footRight.gameObject.SetActive(true);
            footLeft.gameObject.SetActive(true);
            break;

            default: break;
        }
    }

    [ContextMenu("RemoveAllClothes")]
    protected void RemoveAllClothes()
    {
        UnequipClothing(EClothing.Shirt);
        UnequipClothing(EClothing.Pants);
        UnequipClothing(EClothing.Shoes);
    }

}
