using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuroraManager : MonoBehaviour
{
    //object manager
    public GameObject manager;
    //acces the score script
    private Puntaje puntaje_script;

    //player rigidbody
    private Rigidbody2D playerRB;
    //player animator
    private Animator playerAnim;

    //movement speed
    [SerializeField]
    private float playerSpeed;

    //jump force
    public float jumpForce;
    //sliding force
    public float slide;

    //point on player to check is is on the ground
    public Transform groundCheck;
    //distance from ground
    public float checkRadius;
    //layer of the ground
    public LayerMask whatIsGround;


    public Image image, image2, image3;
    //if is on the ground or not
    private bool grounded;
    //if has jumped twice
    private bool doubleJump;
    //time for delay animation
    public float animDelay;
    //game sounds
    public AudioSource romperSound, bombaSound, dieSound, morder, nubeSound, conseguido;
    //prefabs to instantiate effects
    public GameObject explosion, romper, romperVerde, romperNube;

    void Start()
    {
        //get the score script, rigidbody and the animator
        puntaje_script = manager.GetComponent<Puntaje>();
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

        //make false all the animator boolean
        playerAnim.SetBool("isDead", false);
        playerAnim.SetBool("Slide", false);
        playerAnim.SetBool("herido", false);
        playerAnim.SetBool("jump", false);
        playerAnim.SetBool("fall", false);
    }
    private void FixedUpdate()
    {
        //detect if it is on the ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            PlayerSlide();
        }

        //if player is active
        if (playerAnim.GetBool("isDead") == false && playerAnim.GetBool("Slide") == false && playerAnim.GetBool("herido") == false)
        {
            //add the velocity to the player
            playerRB.velocity = new Vector2(playerSpeed, playerRB.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);

            PlayerJumpAnim();

            if (grounded)
            {
                doubleJump = false;
            }
            if (GameObject.FindWithTag("efecto") != null)
            {
                Destroy(GameObject.FindWithTag("efecto"), animDelay);
            }
        }
    }

    //slide function
    public void PlayerSlide()
    {
        if (playerAnim.GetBool("isDead") == false && playerAnim.GetBool("Slide") == false && playerAnim.GetBool("herido") == false)
        {
            if (grounded)
            {
                playerAnim.SetBool("Slide", true);
                playerRB.velocity = new Vector2(slide, 0);
                StartCoroutine(UnableTheSlideAgain());
            }
        }
    }

    //finish the slide and change the animation
    private IEnumerator UnableTheSlideAgain()
    {

        yield return new WaitForSeconds(0.3f);
        if (playerAnim.GetBool("Slide") == true)
        {
            playerAnim.SetBool("Slide", false);
        }
        yield return null;
    }

    //physics jump function
    public void Jump()
    {
        
            if (playerAnim.GetBool("isDead") == false && playerAnim.GetBool("Slide") == false && playerAnim.GetBool("herido") == false)
            {
                if (grounded)
                {
                    playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                }
                if (!doubleJump && !grounded)
                {
                    playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                    doubleJump = true;
                }
            }
        
    }

    //animation jump
    public void PlayerJumpAnim()
    {
        if (playerRB.velocity.y > 0.1)
        {
            playerAnim.SetBool("jump", true);
        }
        
        else if (playerRB.velocity.y < -0.1)
        {
            playerAnim.SetBool("jump", false);
            playerAnim.SetBool("fall", true);
        }
        else
        {
            playerAnim.SetBool("jump", false);
            playerAnim.SetBool("fall", false);
        }
    }

    //find collision with obstacles, items or the end of the level
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "bomba":
                bombaSound.Play();
                playerAnim.SetBool("isDead", true);
                Instantiate(explosion, col.transform.position, col.transform.rotation);
                puntaje_script.GuardarGalletas("Puntaje_Actual", Puntaje.galletas);
                Destroy(col.gameObject);
                StartCoroutine("GameOver");
                break;

            case "roca":
                if (playerAnim.GetBool("Slide") == true)
                {
                    romperSound.Play();
                    Instantiate(romper, col.transform.position, col.transform.rotation);
                    Destroy(col.gameObject);
                }
                else if (playerAnim.GetBool("Slide") == false)
                {
                    dieSound.Play();
                    playerAnim.SetBool("herido", true);
                    puntaje_script.GuardarGalletas("Puntaje_Actual", Puntaje.galletas);
                    StartCoroutine("GameOver");
                }
                break;
            case "nube":
                if (playerAnim.GetBool("Slide") == true)
                {
                    nubeSound.Play();
                    Instantiate(romperNube, col.transform.position, col.transform.rotation);
                    Destroy(col.gameObject);
                }
                else if (playerAnim.GetBool("Slide") == false)
                {
                    dieSound.Play();
                    playerAnim.SetBool("herido", true);
                    puntaje_script.GuardarGalletas("Puntaje_Actual", Puntaje.galletas);
                    StartCoroutine("GameOver");
                }
                break;
            case "barril":
                if (playerAnim.GetBool("Slide") == true)
                {
                    romperSound.Play();
                    Instantiate(romperVerde, col.transform.position, col.transform.rotation);
                    
                    playerAnim.SetBool("herido", true);
                    Destroy(col.gameObject);
                    dieSound.Play();
                    playerAnim.SetBool("herido", true);
                    puntaje_script.GuardarGalletas("Puntaje_Actual", Puntaje.galletas);
                    StartCoroutine("GameOver");
                }
                else if (playerAnim.GetBool("Slide") == false)
                {
                    dieSound.Play();
                    playerAnim.SetBool("herido", true);
                    puntaje_script.GuardarGalletas("Puntaje_Actual", Puntaje.galletas);
                    StartCoroutine("GameOver");
                }
                break;
            case "galleta":
                morder.Play();
                Puntaje.galletas += 1;
                Destroy(col.gameObject);
                break;

            case "premio":
                conseguido.Play();
                Puntaje.premios += 1;
                Puntaje.DibujarPremios();
                Destroy(col.gameObject);
                break;

            case "final":
                puntaje_script.GuardarGalletas("Puntaje_Actual", Puntaje.galletas);

                PlayerPrefs.SetInt("UltimosOsosGanados" , Puntaje.premios);
                if ( PlayerPrefs.GetInt(SceneManager.GetActiveScene().name)< Puntaje.premios)
                {
                    PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, Puntaje.premios);
                }
                StartCoroutine("Siguiente");
                break;
            case "finalDeJuego":
                puntaje_script.GuardarGalletas("Puntaje_Actual", Puntaje.galletas);
                PlayerPrefs.SetInt("UltimosOsosGanados", Puntaje.premios);
                if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name) < Puntaje.premios)
                {
                    PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, Puntaje.premios);
                }
                StartCoroutine("Siguiente");
                break;
            case "enemigo":

                dieSound.Play();
                playerAnim.SetBool("isDead", true);
                puntaje_script.GuardarGalletas("Puntaje_Actual", Puntaje.galletas);
                if(col.gameObject.name == "Avion")
                {
                    Debug.Log("aqui");
                    Rigidbody2D a = col.GetComponent<Rigidbody2D>();
                    a.velocity = new Vector2(2, -1);
                }
                StartCoroutine("GameOver");
                break;
            case "Barranco":

                dieSound.Play();
                playerAnim.SetBool("isDead", true);
                puntaje_script.GuardarGalletas("Puntaje_Actual", Puntaje.galletas);
                GetComponent<Collider2D>().enabled = false;
                StartCoroutine("GameOver");
                break;
            
        }
    }

    //load next scene
    IEnumerator Siguiente()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Resultado");
    }

    //game completed function
    IEnumerator JuegoCompletado()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Niveles");
    }

    //game over function
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("GameOver");
    }
}
