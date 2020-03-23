using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour {

    //enemy starting position
    public GameObject inicio;
    //enemy returning position
    public GameObject fin;

    //enemy animator
    private Animator enemyAnim;
    //enemy movement speed
    public float enemySpeed;
    //dying audio
    public AudioSource muerto;
    //bool to detect movement direction
    public bool isGoingRight;
    //bool if it is on the ground
    public bool grounded;


    void Start()
    {
        //get the animator 
        enemyAnim = GetComponent<Animator>();
        //set the animation to not hitted
        enemyAnim.SetBool("golpeado", false);

        //start facing to the direction it is moving
        if (!isGoingRight)
        {
            transform.position = inicio.transform.position;
        }
        else
        {
            transform.position = fin.transform.position;
        }
    }


    void Update()
    {
        //if it is not hit
        if (enemyAnim.GetBool("golpeado") == false)
        {
            //move to the side is facing
            if (!isGoingRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, fin.transform.position, enemySpeed * Time.deltaTime);
                if (transform.position == fin.transform.position)
                {
                    isGoingRight = true;
                    GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            if (isGoingRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, inicio.transform.position, enemySpeed * Time.deltaTime);
                if (transform.position == inicio.transform.position)
                {
                    isGoingRight = false;
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
    }

    //detect collision with player
  void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            muerto.Play();
            enemyAnim.SetBool("golpeado", true);
            if(gameObject.name == "Avion")
            {
                Rigidbody2D a = GetComponent<Rigidbody2D>();
                a.velocity = new Vector2(2, -1);
            }
        }
    }
}
