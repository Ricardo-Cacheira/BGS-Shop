using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EClothing
{
    Shirt,
    Pants,
    Shoes    
}

public class PlayerVisuals : MonoBehaviour
{
    [Header("Current Clothes")]
    private Shirt shirt;
    private Pants pants;
    private Shoes shoes;

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
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Testing in Editor
    private void OnValidate()
    {
        EquipClothing(item);
    }

    private void EquipClothing(ClothingItem newItem)
    {
        if(newItem == null)
            return;

        switch (newItem.type)
        {
            case EClothing.Shirt:
            shirt = (Shirt)newItem;
            shirtTorso.sprite = shirt.torso;
            shirtSleeveRight.sprite = shirtSleeveLeft.sprite = shirt.arm;
            break;

            case EClothing.Pants:
            pants = (Pants)newItem;
            pantsWaist.sprite = pants.waist;
            pantLegRight.sprite = pantLegLeft.sprite = pants.leg;
            break;

            case EClothing.Shoes:
            shoes = (Shoes)newItem;
            shoeRight.sprite = shoeLeft.sprite = shoes.shoe;
            footRight.gameObject.SetActive(false);
            footLeft.gameObject.SetActive(false);
            break;

            default: break;
        }

        item = null;
    }

    private void UnequipClothing(EClothing type)
    {
        switch (type)
        {
            case EClothing.Shirt:
            shirtTorso.sprite = null;
            shirtSleeveRight.sprite = shirtSleeveLeft.sprite = null;
            break;

            case EClothing.Pants:
            pantsWaist.sprite = null;
            pantLegRight.sprite = pantLegLeft.sprite = null;
            break;

            case EClothing.Shoes:
            shoeRight.sprite = shoeLeft.sprite = null;
            footRight.gameObject.SetActive(true);
            footLeft.gameObject.SetActive(true);
            break;

            default: break;
        }
    }

}
