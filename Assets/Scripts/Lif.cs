using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lif : MonoBehaviour
{
    //Public Fields
    public float speed = 1;
    //Private Fields
    private Rigidbody2D rb;
    private Animator animator;
    private float horizontalValue;
    private float runSpeedModifier = 2;
    private bool isRunning = false;
    private bool facingRight = true;
    private bool isDead = false;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(CanMoveOrInteract() == false)
            return;

        horizontalValue = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
    
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
    }

    void FixedUpdate()
    {
        Move(horizontalValue);
    }

    public bool CanMoveOrInteract()
    {
        bool can = true;

        if (FindObjectOfType<InteractionSystem>().isExamining)
            can = false;
        if (FindObjectOfType<InventorySystem>().isOpen)
            can = false;
        if (isDead)
            can = false;

        return can;
    }

    void Move(float dir)
    {
        float xVal = dir * speed * 100 * Time.fixedDeltaTime;
        if(isRunning)
        {
            xVal *= runSpeedModifier;
        }
        Vector2 targetVelocity = new Vector2(xVal,rb.velocity.y);
        rb.velocity = targetVelocity;

        Vector3 currentScale = transform.localScale;

        if(facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-6, 6, 6);
            facingRight = false;
        }
        else if(!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(6, 6, 6);
            facingRight = true;
        }

        //0 for idle, 4 for walking, 8 for running.
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
    }
    
    public void Die()
    {
        isDead = true;

    }
    public void ResetPlayer()
    {
        isDead = false;
    }
}
