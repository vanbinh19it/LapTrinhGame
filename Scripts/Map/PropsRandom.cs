using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PropsRandom : MonoBehaviour
{
    [SerializeField] private List<GameObject> _PropSpawnPoints;
    [SerializeField] private List<GameObject> _PropPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
        foreach (GameObject prefab in _PropSpawnPoints)
        {
            int random= Random.Range(0, _PropPrefabs.Count);
            //Debug.Log(random);
            GameObject newGameobject=Instantiate(_PropPrefabs[random], prefab.transform.position, Quaternion.identity);
            newGameobject.transform.parent = prefab.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
