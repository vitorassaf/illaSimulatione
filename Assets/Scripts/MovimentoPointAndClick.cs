using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimentoPointAndClick : MonoBehaviour
{
    public Vector2 posicaoAndar;
    public float velocidade = 1f;


    private Rigidbody2D rb;

    public GameObject sprite;
    private float originalScaleX;

    private Animator anim;

    public LayerMask layerMask;

    public string nome_CenaLivraria;

    private Transform target;
    void Start()
    {
        anim = GetComponent<Animator>();
        originalScaleX = sprite.transform.localScale.x;

        posicaoAndar = transform.position;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit;

        if (Input.GetButtonDown("Click"))
        {
            posicaoAndar = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
            target = hit.transform;
        }

        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) < 1f)
            {
                SceneManager.LoadScene(nome_CenaLivraria);
            }
        }

        if (Vector2.Distance(transform.position, posicaoAndar) > 0.05f)
        {
            Vector2 normalized = (posicaoAndar - (Vector2)transform.position).normalized;


            rb.velocity = normalized * velocidade;

            anim.SetBool("Andando", true);
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("Andando", false);
        }

        Flip();
    }

    public void Flip()
    {
        if (rb.velocity.x == 0) //Não girar se não tiver velocidade
            return;

        if (rb.velocity.x > 0)
        {
            sprite.transform.localScale = new Vector3(originalScaleX, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            sprite.transform.localScale = new Vector3(originalScaleX * -1, transform.localScale.y, transform.localScale.z);
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PassaFase")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
    */
}
    

    
