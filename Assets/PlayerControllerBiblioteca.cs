using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBiblioteca : MonoBehaviour
{

    private int pontuacao = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Coletor")
        {

            Debug.Log("Está Colidindo");
            Destroy(collision.gameObject);
            pontuacao++;
        }
    }
}
