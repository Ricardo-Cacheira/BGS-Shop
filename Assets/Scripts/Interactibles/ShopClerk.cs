using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopClerk : MonoBehaviour, IInteractible
{
    [SerializeField] private Shop shop;
    [SerializeField] private Transform panel;
    private Vector3 panelSize;

    public string InteractionPrompt => throw new System.NotImplementedException();

    public bool Interact(PlayerInteractor interactor)
    {
        if(shop.gameObject.activeInHierarchy)
            return false;
        else
        {
            shop.gameObject.SetActive(true);
            return true;
        }
    }

    private void Awake()
    {
        panelSize = panel.localScale;
        panel.localScale = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            panel.localScale = Vector3.zero;
            LeanTween.scale(panel.gameObject, panelSize, 0.5f).setEase(LeanTweenType.easeInOutCirc);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        LeanTween.scale(panel.gameObject, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInOutCirc);        
    }
}
