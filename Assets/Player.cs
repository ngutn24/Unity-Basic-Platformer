using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10; // Adjustable movement speed of the player
    public float jumpHeight = 20; // Adjustable jump height of the player
    private Rigidbody2D rigid; // A RigidBody2D, how we'll get movement

    public LayerMask ground; // For the raycast we'll use later, assign the layer 
                             // containing your ground objects in the Unity project manager

    // Start is called before the first frame update
    void Start()
    {
        // Assigns the object's Rigidbody2D so we can reference it to move the player
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Basic right and left movement
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.velocity = new Vector2(-1 * moveSpeed, rigid.velocity.y);
        } else // If there's no input, the player is just falling
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }

        // To stop infinite jumping, detects when the player is near objects in the the 
        // ground layer you assigned
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, ground);
        // By default Jump is set to spacebar but you can change it in Project Settings
        if (Input.GetButtonDown("Jump") && hit)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpHeight);
        }
    }
}
