using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public float moveSpeed = 10.0f;
    Vector3 direction = new Vector3(0,0,0);
    Vector2 _direction = new Vector2(1,1);
    float horizontalInput;
    float verticalInput;
    public Transform orientation;
    Vector3 moveDirection;
    Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
         rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // MyInput();

        this.transform.localEulerAngles = direction;
       
        if(Input.GetKey("w")){
            animator.SetBool("isWalking",true);
            rb.velocity = new Vector3(this.transform.forward.x, rb.velocity.y, this.transform.forward.z) * moveSpeed;
        }
        else{
            animator.SetBool("isWalking",false);
            rb.velocity = new Vector3(0,0,0);
        }
        if(Input.GetKeyDown("a")){
            direction.y -= 90f;
        }
        if(Input.GetKeyDown("d")){
            direction.y += 90f;
        }
        if(Input.GetKeyDown("s")){
            direction.y += 180f;
        }
    }

    // private void MyInput()
    // {
    //     horizontalInput = Input.GetAxisRaw("Horizontal");
    //     verticalInput = Input.GetAxisRaw("Vertical");
    // }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Exit_Door"){
            Debug.Log("GameWon");
            Debug.Log("LevelCompleted");
        }
    }
}
