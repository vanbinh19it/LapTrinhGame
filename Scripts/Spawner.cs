using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : CMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    public int prefabsCount = 0;
    
    public static Spawner Instance;

    protected override void Awake()
    {
        base.Awake();
        Spawner.Instance = this;
        prefabsCount=this.prefabs.Count;
    }

    protected override void LoadComponents()
    {
        LoadPrefabs();
    }

    private void LoadPrefabs()
    {
        
        if(this.prefabs.Count >0) return;
        Transform prefabsObj=transform.Find("Prefabs");
        foreach (Transform prefab in prefabsObj)
        {
            this.prefabs.Add(prefab);

        }
        this.HidePrefabs();

        Debug.Log(this.name+": LoadPrefabs", gameObject);
    }

    protected void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public Transform Spawn(int so,Vector3 pos, Quaternion quaternion)
    {
        // if(tag!=" ")
        // {
        //     string a=tag;
        //     Transform childPrefabs=;
        // }
        Transform prefab = this.prefabs[so];
        Transform newPrefab = Instantiate(prefab, pos, quaternion);
        return newPrefab;
    }
}
