using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCountChecker : MonoBehaviour
{
    public PlayerInventory playerInventory; // Reference to the PlayerInventory script.
   
    private void Start()
    {
        {
        if (SteamManager.Initialized) { return;}
        }
    
        // Ensure that the playerInventory reference is set in the Inspector or through code.
        if (playerInventory == null)
        {
            Debug.LogError("Player Inventory reference is not set.");
        }
        else
        {
            // Subscribe to the OnDiamondCollected event.
            playerInventory.OnDiamondCollected.AddListener(CheckDiamondCount);
        }
    }

    private void CheckDiamondCount(PlayerInventory inventory)
    {
        // Check if the number of diamonds in the player's inventory is 20 or more.
        if (inventory.NumberOfDiamonds >= 20)
        {
            Debug.Log("Player has 20 or more diamonds. Performing the action.");
            
            Steamworks.SteamUserStats.SetAchievement("ACH_COLLECTIBLES");
            Steamworks.SteamUserStats.StoreStats();
        }
    }
}