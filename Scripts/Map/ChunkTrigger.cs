using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController myChunk;
    public GameObject targetMap;
    // Start is called before the first frame update
    void Start()
    {
        myChunk= FindObjectOfType<MapController>();

    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            myChunk.currentChunk=targetMap;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            if(myChunk.currentChunk==targetMap)
            {
                myChunk.currentChunk=null;
            }
        }
    }
    
}
