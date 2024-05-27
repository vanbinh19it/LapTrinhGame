using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkRadius;
    public Vector3 noTerrainPosition;
    public GameObject currentChunk;
    public LayerMask terrainMask;
    PlayerMovement playerMovement;

    [SerializeField] private List<GameObject> spawnedChunks;
    private GameObject lastChunk;
    [SerializeField] private float maxOpDis;
    [SerializeField] private float opDis;
    [SerializeField] private float time;
    [SerializeField] private float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement=FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        ChunksOptimizer();
    }

    private void ChunkChecker()
    {
        if(!currentChunk)
        {
            return;
        }
        if(playerMovement.Movement.x>0 && playerMovement.Movement.y==0)//right
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkRadius, terrainMask))
            {
                noTerrainPosition=currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        } else if(playerMovement.Movement.x<0 && playerMovement.Movement.y==0) //left
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkRadius, terrainMask))
            {
                noTerrainPosition=currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }else if(playerMovement.Movement.x==0 && playerMovement.Movement.y>0) //up
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkRadius, terrainMask))
            {
                noTerrainPosition=currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }else if(playerMovement.Movement.x==0 && playerMovement.Movement.y<0) //down
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkRadius, terrainMask))
            {
                noTerrainPosition=currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }else if(playerMovement.Movement.x>0 && playerMovement.Movement.y>0) //right up
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Up").position, checkRadius, terrainMask))
            {
                noTerrainPosition=currentChunk.transform.Find("Right Up").position;
                SpawnChunk();
            }
        }else if(playerMovement.Movement.x>0 && playerMovement.Movement.y<0) //right down
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Down").position, checkRadius, terrainMask))
            {
                noTerrainPosition=currentChunk.transform.Find("Right Down").position;
                SpawnChunk();
            }
        }else if(playerMovement.Movement.x<0 && playerMovement.Movement.y>0) //left up
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Up").position, checkRadius, terrainMask))
            {
                noTerrainPosition=currentChunk.transform.Find("Left Up").position;
                SpawnChunk();
            }
        }else if(playerMovement.Movement.x<0 && playerMovement.Movement.y<0) //left down
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Down").position, checkRadius, terrainMask))
            {
                noTerrainPosition=currentChunk.transform.Find("Left Down").position;
                SpawnChunk();
            }
        }

        
    }
    private void SpawnChunk()
    {
        int rand=Random.Range(0, terrainChunks.Count);
        lastChunk=Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(lastChunk); 
    }
    private void ChunksOptimizer()
    {
        time+=Time.fixedDeltaTime;
        if(time<maxTime)
        {
            return;
        }
        time =0;
        foreach (GameObject chunk in spawnedChunks)
        {
            opDis= Vector3.Distance(player.transform.position, chunk.transform.position);
            if(opDis>=maxOpDis)
            {
                chunk.SetActive(false);
            }
            else 
            {
                chunk.SetActive(true);
            }
        }
    }
    
}
