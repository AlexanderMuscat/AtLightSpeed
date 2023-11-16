using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public AudioSource audioPlayer;
    public GameObject[] objectsToDeactivate; // An array of 21 objects to deactivate.
    private int currentIndex = 0; // Keeps track of the current object to deactivate.
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.DiamondCollected();
            audioPlayer.Play();
            gameObject.SetActive(false);

            // Check if there are more objects to deactivate.
            if (currentIndex < objectsToDeactivate.Length)
            {
                // Deactivate the current object.
                DeactivateCurrentObject();
                currentIndex++;
            }
        }
    }
        private void DeactivateCurrentObject()
    {
        if (currentIndex >= 0 && currentIndex < objectsToDeactivate.Length)
        {
            objectsToDeactivate[currentIndex].SetActive(false);
        }
    }
}