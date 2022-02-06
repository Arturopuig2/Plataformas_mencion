using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int speed;
    public int force;
    //float movement;
    Rigidbody2D playerRB;
    SpriteRenderer direccion;




    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        direccion=GetComponent<SpriteRenderer>();

    }


    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");

        if (movement < 0){
           // direccion.flipX = enabled;
            direccion.flipX=true;


        }
        else if(movement > 0)
        {
            //direccion.flipX = !enabled;
            direccion.flipX = false;

        }

        playerRB.velocity = new Vector2(movement * force, playerRB.velocity.y);

     //   playerRB.velocity = Vector2.right *movement* speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
