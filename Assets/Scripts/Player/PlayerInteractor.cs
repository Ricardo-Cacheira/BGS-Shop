using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private IInteractible currentObject;

    //Track interactable objects in range of the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        currentObject = other.GetComponent<IInteractible>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        currentObject = null;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && currentObject != null)
        {
            currentObject.Interact(this);
        }
    }
}
