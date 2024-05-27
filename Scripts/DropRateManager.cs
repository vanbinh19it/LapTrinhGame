using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
    public class Drops
    {
        public string name;
        public GameObject itemPrefab;
        public float dropRate;
    }

    public List<Drops> drops;

    private void OnDestroy() {
        if(!gameObject.scene.isLoaded)
        {
            return;
        }
        float randomNumber= UnityEngine.Random.Range(0, 100);
        List<Drops> possibleDrops = new List<Drops>();
        foreach (Drops rate in drops)
        {
            if(randomNumber <= rate.dropRate)
            {
                possibleDrops.Add(rate);
            }
        }
        
        //để 1 quái chỉ có thể rơi ra 1 vật phẩm
        if(possibleDrops.Count > 0)
        {
            Drops drop = possibleDrops[UnityEngine.Random.Range(0, possibleDrops.Count-1)];
            Instantiate(drop.itemPrefab, transform.position, Quaternion.identity);
        }
    }
}
