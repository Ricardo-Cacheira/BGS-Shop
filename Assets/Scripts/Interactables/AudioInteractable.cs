using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteractable : MonoBehaviour, IInteractible
{
    [SerializeField] private AudioSource ring;

    public bool Interact(PlayerInteractor interactor)
    {
        if(ring.isPlaying)
            return false;
        else
        {
            ring.Play();
            return true;
        }
    }
}
