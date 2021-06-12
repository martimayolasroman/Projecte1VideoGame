using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player2Moviment : MonoBehaviour
{
    public static Player2Moviment instance;
    private Collisions coll;
    private Rigidbody2D rb;
    [HideInInspector]
    public Animator anim;
    SpriteRenderer sr;
    public GameObject joystick1;
    MovmentCamera mc;
    public GameObject Fade;
    public GameObject Camera;
    public GameObject DieMenu;
    private CapsuleCollider2D capcol;
    public GameObject RunSmoke;
    Coins_Saved menuManager;



    //stats

    public float speed = 10;
    public float jumpForce = 10;


    public float fallGravity = 1.5f;
    public float lowJumpGravity = 1f;


    public int extraJumps = 1;
    private int extraJumpsAux;

    public float coyoteTime = 0.01f;
    private Vector2 initGravity;

    //bools

    public bool hasDashed = false;
    bool enableGravityController = true;
    bool canMove = true;
    bool groundTouch = false;
    bool facingRight = true;
    bool startBuffering = false;
    public bool wallSliding = false;
    bool isInCoyoteTime = false;
    bool canJump = true;
    bool moveDie = false;

    private AudioSource audioPlayer;
    public AudioClip JumpClip;
    public AudioClip DieClip;

    public GameObject SlowPS;





    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collisions>();
        anim = GetComponent<Animator>();
        extraJumpsAux = extraJumps;
        sr = GetComponent<SpriteRenderer>();
        initGravity = Physics2D.gravity;
        mc = FindObjectOfType<MovmentCamera>();
        Fade.SetActive(false);
        capcol = GetComponent<CapsuleCollider2D>();
        DieMenu.SetActive(false);
        audioPlayer = GetComponent<AudioSource>();

        menuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<Coins_Saved>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);


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

        if (moveDie)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Camera.transform.position.x, 0, 0), Time.deltaTime * (speed * 2));

        }

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

        if (coll.onGround && (rb.velocity.x > 0 || rb.velocity.x < 0))
        {
            RunSmoke.SetActive(true);

        }
        else
        {

            RunSmoke.SetActive(false);
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


       
        if(speed == 7)
        {
            SlowParticles();
        }




    }


 
    private void Move(Vector2 dir)
    {
        rb.velocity = new Vector2(joystick1.GetComponent<Joystick>().Horizontal * speed, rb.velocity.y);
        if (facingRight == false && joystick1.GetComponent<Joystick>().Horizontal > 0) Flip();
        else if (facingRight == true && joystick1.GetComponent<Joystick>().Horizontal < 0) Flip();

    }

    private void Jump()
    {

        if (canJump)
        {
            audioPlayer.clip = JumpClip;
            audioPlayer.Play();
            rb.velocity = new Vector2(rb.velocity.x, 0); //reset vel. y
            rb.velocity += Vector2.up * jumpForce; // add jumpForce to vel. y
        }
    }

    public void DoJump()
    {
        canJump = true;
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

    public void NotJump()
    {
        canJump = false;
    }
    


    private void JumpGravityController()
    {


        if (rb.velocity.y < 1)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallGravity) * Time.deltaTime;
            Physics2D.gravity = new Vector2(0, -3);

        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpGravity) * Time.deltaTime;
            Physics2D.gravity = new Vector2(0, -9.8f);

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

    public void DieP2()
    {
        //MORT
        audioPlayer.clip = DieClip;
        audioPlayer.Play();
        StartCoroutine(DieAnimation());
    }

    void StopisInCoyoteTime()
    {
        isInCoyoteTime = false;
    }

    //retorna al jugador a l'últim checkpoint guardat
  


    public void StopPlayer()
    {
       
        speed = 0;
        Invoke("RestarSpeed", 1);
        canJump = false;

    }

    public void RestarSpeed()
    {
       
        speed = 10;
        canJump = true;

    }
    IEnumerator DieAnimation()
    {
        // POSICIO, FADE, TEXTO
        mc.movementSpeed = 0;
        StopPlayer();
        anim.SetTrigger("Die");
        //ANIMACIOPLAYER
        yield return new WaitForSeconds(0.2f);
        capcol.isTrigger = true;
        rb.gravityScale = 0;
        moveDie = true;
        Fade.SetActive(true);
        //FADE
        StopPlayer();
        yield return new WaitForSeconds(2);
        DieMenu.SetActive(true);
        menuManager.coinValue = 0;
        //MENU MUERTE
        Time.timeScale = 0;

    }

    public void SlowParticles()
    {
        //Instantiate(SlowPS, transform.position, Quaternion.identity);

        Debug.Log("fffff");
        GameObject Exp = Instantiate(SlowPS,/* transform.position */new Vector3(transform.position.x,transform.position.y - 1, transform.position.z ), Quaternion.identity);
        Exp.GetComponent<ParticleSystem>().Play();
    }
}
