using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Player2Moviment : MonoBehaviour
{
    public static Player2Moviment instance;
    private Collisions coll;
    private Rigidbody2D rb;
    [HideInInspector]
    public Animator anim;
    SpriteRenderer sr;
    public GameObject joystick1;
    //stats

    public float speed = 10;
    public float jumpForce = 10;


    public float fallGravity = 1.5f;
    public float lowJumpGravity = 1f;


    public int extraJumps = 1;
    private int extraJumpsAux;

    public float coyoteTime = 0.01f;

    //bools

    public bool hasDashed = false;
    bool enableGravityController = true;
    bool canMove = true;
    bool groundTouch = false;
    bool facingRight = true;
    bool startBuffering = false;
    public bool wallSliding = false;
    bool isInCoyoteTime = false;





   

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collisions>();
        anim = GetComponent<Animator>();
        extraJumpsAux = extraJumps;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);

        Debug.Log(extraJumps);
        // CAMINAR

        if (canMove ) Move(dir);

        // SALT
        if (Input.GetButtonDown("Jump")  /*|| touchPos.x > 0*/)
        {
            DoJump();
        }

        if (startBuffering) StartCoroutine(JumpBuffering());

        if (enableGravityController) JumpGravityController();

        else wallSliding = false;

        //ANIMATIONS


        anim.SetInteger("Speed", (int)rb.velocity.x);

        if (groundTouch == true)
        {
            anim.SetBool("IsJumping", false);
        }
        else
        {
            anim.SetBool("IsJumping", true);

        }



        //GROUND COLISIONS

        if (coll.onGround && !groundTouch) //Frame en el que toca el terra
        {
            groundTouch = true;
            extraJumps = extraJumpsAux;

        }

       

        if (!coll.onGround && groundTouch) //Frame en el q deixa de tocar el terra
        {
            groundTouch = false;

            if (rb.velocity.y <= 0) isInCoyoteTime = true;
            Invoke("StopisInCoyoteTime", coyoteTime);
        }

        if (rb.velocity.y < -15 && hasDashed == false) rb.velocity = new Vector2(rb.velocity.x, -15);


       





    }


 
    private void Move(Vector2 dir)
    {
        rb.velocity = new Vector2(joystick1.GetComponent<Joystick>().Horizontal * speed, rb.velocity.y);
        if (facingRight == false && joystick1.GetComponent<Joystick>().Horizontal > 0) Flip();
        else if (facingRight == true && joystick1.GetComponent<Joystick>().Horizontal < 0) Flip();

    }

    private void Jump()
    {


        rb.velocity = new Vector2(rb.velocity.x, 0); //reset vel. y
        rb.velocity += Vector2.up * jumpForce; // add jumpForce to vel. y
    }

    public void DoJump()
    {
       
            if (coll.onGround && rb.drag == 0)//SALT EN TERRA
            //rb ==0 vol dir que no esta fent dash, si no es posa, quan el jugador esta fent el dash conta el terra i salta,
            //el dash acaba quan esta a l'aire, pero ha fet el dash, ha tocat el terra,
            // i no ha recuperat l'us del dash (pq no l ha acabat mentre estava al terra) i pot confodre al jugador,
            // aixi que faig que mentre estigui fent el dash no pugui saltar per evita
            {
                Jump();
            }
            else if (extraJumps > 0 && rb.drag == 0) //SALT EN AIRE rb==0 vol dir que no esta fen dash
            {
                Jump();
                extraJumps--;
            }

            else if (isInCoyoteTime)
            {
                Jump();
                isInCoyoteTime = false;
            }

            //if(coll.onGround && extraJumps == 0)
            // {
            //extraJumps ==
            // }

            //JUMP BUFFERING 
            //quan vols saltar i encara no estas al terra, es guarda l input per saltar en el frame que toca el terra
            else
            {
                startBuffering = true;
            }
        }
    


    private void JumpGravityController()
    {

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallGravity) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpGravity) * Time.deltaTime;
        }
    }




   

    IEnumerator CoyoteTimer()
    {
        Jump();
        yield return new WaitForSeconds(coyoteTime);
    }

    IEnumerator JumpBuffering()
    {

        //S'APLICA AL SALT I AL DASH

        if (groundTouch && rb.drag == 0)
        {
            Jump();
            startBuffering = false;
        }

        yield return new WaitForSeconds(0.2f);
        startBuffering = false;
    }

    void Flip()
    {
        facingRight = !facingRight;
        //Vector3 aux = transform.localScale;
        //aux.x *= -1;
        //transform.localScale = aux;
        sr.flipX = !sr.flipX;
    }



    void StopisInCoyoteTime()
    {
        isInCoyoteTime = false;
    }

    //retorna al jugador a l'últim checkpoint guardat
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.tag == "disparo")
        {
        }

       
    }

}
