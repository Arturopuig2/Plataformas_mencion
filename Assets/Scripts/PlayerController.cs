using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed, force;
    float movimientoHorizontal, movimientoVertical;
    Rigidbody2D playerRB;
    SpriteRenderer direccion;
    Animator MyAnim;
    Vector2 movimiento;
    public float jumpForce;
    bool isGrounded = true;
    RaycastHit2D hit;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        direccion=GetComponent<SpriteRenderer>();
        MyAnim = GetComponent<Animator>();
        Physics2D.queriesStartInColliders = false;  //Para evitar que se detecte a sí mismo.
    }
    private void FixedUpdate()
    {

        MyAnim.SetFloat("VerticalVelocity", playerRB.velocity.y);
        Debug.Log("Velocidad en y " + playerRB.velocity.y);

        movimientoHorizontal = Input.GetAxisRaw("Horizontal");       
        if (movimientoHorizontal < 0){
            direccion.flipX = true;
            }else if (movimientoHorizontal > 0){
            direccion.flipX = false;
            }

        movimientoVertical = Input.GetAxisRaw("Jump");
        if (movimientoVertical > 0 && isGrounded == true)
        {
            playerRB.velocity=new Vector2(playerRB.velocity.x, 0); //neutralizar la fuerza que llevase.
            playerRB.AddForce(new Vector2(0, jumpForce),ForceMode2D.Impulse);

                isGrounded = false;
                MyAnim.SetBool("IsGrounded", false);

        }


        hit = Physics2D.Raycast(transform.position, -Vector2.up);

        if (hit.collider != null && isGrounded==false && playerRB.velocity.y<0)
        {
            if (hit.distance < 0.4)
            {
                Debug.Log(hit.collider.gameObject.name + " a " + hit.distance);
                isGrounded = true;
                MyAnim.SetBool("IsGrounded", true);

            }
            else
            {
                Debug.Log("Estoy en pleno salto");
            }


        }


        //else
        //{
        //   // Saltar.SetBool("IsGrounded", true);
        //}

        playerRB.velocity = new Vector2(movimientoHorizontal * speed, playerRB.velocity.y);

        //playerRB.velocity = new Vector2(movimientoHorizontal * force, movimientoVertical*force*2);



        //playerRB.velocity = new Vector2(movement * force, movementVertical * force);

        // float horizontalVelocity = movimiento.normalized.x * speed;
        //  playerRB.velocity = new Vector2(horizontalVelocity*force, movementVertical * force);

        //  playerRB.velocity = Vector2.right *movement* speed;

        MyAnim.SetFloat("MoveSpeed", Mathf.Abs(movimientoHorizontal));

    }

    // Update is called once per frame
    void Update()
    {
    }
}
