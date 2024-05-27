using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats playerStats;
    CircleCollider2D playerCollector;
    public float pullspeed;
    void Start ()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        playerCollector = GetComponent<CircleCollider2D>();
    }
    void Update ()
    {
        playerCollector.radius = playerStats.CurrentMagnet;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.TryGetComponent(out ICollectible collectible))
        {
            Debug.Log ("playerCollector: "+playerCollector.radius);
            //pull animation
            Rigidbody2D rb= other.gameObject.GetComponent<Rigidbody2D>();
            //Vector2 pointing from the item to the player
            Vector2 forceDirection= (this.transform.position - other.transform.position).normalized;
            rb.AddForce(forceDirection*pullspeed);


            collectible.Collect();
        }
    }
}
