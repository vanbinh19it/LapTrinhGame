using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLv : MonoBehaviour
{
    public static SelectLv instance;
    [SerializeField]string lvName;
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

    public void SelectLvName(string lvName)
    {
        this.lvName = lvName;
    }
    public static string GetLvName()
    {
        return instance.lvName;
    }
}
