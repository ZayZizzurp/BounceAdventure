using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float moveSpeed = 5f; 
    //public GameObject eatFace;
    public CircleCollider2D ballCollider;
    public bool canMove;
    public float position;
    Rigidbody2D rb2D;
    
    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    private void Move(float dx, float dy)
    {
        rb2D.velocity = new Vector2(dx * moveSpeed, dy * moveSpeed);
    }

    // Update is called once per frame
    void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (canMove)
        {
            Move(x, y);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            canMove = !canMove;
        }

       
       

    }
}
