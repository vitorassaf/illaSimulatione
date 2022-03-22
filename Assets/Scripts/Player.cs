using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField]
    public int pontuacao = 0;
    private float move;
    public float moveSpeed;
    public float JumpForce;
    public Text pontuacaoText;

    [SerializeField]
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animationRosangela;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        animationRosangela = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        move = Input.GetAxis("Horizontal");

        if(move < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        
        if(move !=0)
        {
            animationRosangela.SetBool("Walking", true);
        }
        else
        {
            animationRosangela.SetBool("Walking", false);

        }

        Jump();



    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Coletor")
        {

            Debug.Log("Está Colidindo");
            Destroy(collision.gameObject);
            pontuacao++;

            pontuacaoScoretext();
            
        }

        if(collision.gameObject.tag == "Queda")
        {
            Debug.Log("Personagem Morreu !! ");
            Destroy(collision.gameObject);
        }


    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    public void pontuacaoScoretext()
    {
        
    }



}
