using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector instance;
    public PlayerScriptableObject playerData;
    private void Awake() {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Debug.LogWarning("EXTRA "+ this + " DELETED");
            Destroy(gameObject);
        }
    }
    public static PlayerScriptableObject GetData()
    {
        return instance.playerData;
    }

    public void SelecteCharacter(PlayerScriptableObject player)
    {
        playerData=player;
    }
    public void DestroySingleton()
    {
        instance = null;
        Destroy(this.gameObject);
    }

}
