using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathPotion : PickUp, ICollectible
{
    [SerializeField] private int heathToRestore;
    public void Collect()
    {
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        playerStats.Recovery(heathToRestore);
    }

    

    
}
