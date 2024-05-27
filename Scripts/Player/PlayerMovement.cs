using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private Camera _Camera; 
    private PlayerStats player;
    [SerializeField]private Vector2 movement;
    public Vector2 lastMoveVector;
    public Vector2 Movement{
        get { return movement; }
        private set {}
    }
    // Start is called before the first frame update
    private void Awake() {
        player=GetComponent<PlayerStats>();
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        lastMoveVector=new Vector2(0, 1);
    }
    private void OnMovement(InputValue value)
    {
        if(GameManager.instance.isGameOver)
        {
            return;
        }
        movement= value.Get<Vector2>();
       // Debug.Log(movement);
        if(movement.x!=0 || movement.y!=0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
            animator.SetBool("isMove", true);
            lastMoveVector = movement;
        }
        else {animator.SetBool("isMove", false);}
    }
    

    
    
    private void FixedUpdate() {
        
        rb.MovePosition(rb.position+movement*Time.fixedDeltaTime*player.CurrentSpeed);
    }
}
