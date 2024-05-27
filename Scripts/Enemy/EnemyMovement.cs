using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    //[SerializeField] private float _rotationSpeed;
    private Rigidbody2D rb;
    private Vector2 _targetDirection;
    private PlayerAwarenessController _playerAwareController;
    private EnemyStats enemy;
    
    private void Awake() {
        enemy=GetComponent<EnemyStats>();
        rb=GetComponent<Rigidbody2D>();
        _playerAwareController=GetComponent<PlayerAwarenessController>();
     //   _rotationSpeed=100;
        //speed=1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        // if(_playerAwareController.AwareOfPlayer)
        // {
            _targetDirection=_playerAwareController.DirectiontoPlayer;
        // }
        // else _targetDirection=Vector2.zero;
    }

    private void RotateTowardsTarget()
    {
        // if(_targetDirection==Vector2.zero) return;
        // Quaternion targetRotation= Quaternion.LookRotation(transform.forward, _targetDirection);
        // Quaternion rotation=Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed*Time.fixedDeltaTime);
        if(_targetDirection.x<0){
            transform.rotation= new Quaternion(0, 180, 0, 0);
        }
        else transform.rotation= new Quaternion(0, 0, 0, 0);
        
        
    }

    private void SetVelocity()
    {
        //Vector2 move= Vector2.MoveTowards(transform.position, _targetDirection, 5);
        if(_targetDirection==Vector2.zero)
        {
            rb.velocity=Vector2.zero;
        }
        else rb.velocity=_targetDirection*enemy.currentMoveSpeed;
    }

    // private void FixedUpdate() {
    //     // Quaternion targetRotation= Quaternion.LookRotation(transform.forward, rb.position+movement);
    //     // Quaternion rotation= Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed*Time.fixedDeltaTime);

    //     rb.MovePosition(rb.position+movement*Time.fixedDeltaTime);
    //     if(movement.x<0)
    //     transform.rotation=new Quaternion(0, 180, 0, 0);
    // }
    // private void OnCollisionEnter2D(Collision2D other) {
        
    // }
}
