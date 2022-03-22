using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJogadorPointAndClick : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject quemSeguir;
    void Start()
    {
        quemSeguir = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Só seguir o jogador(quemseguir) no eixo x
        transform.position = new Vector3(quemSeguir.transform.position.x, transform.position.y, transform.position.z);
    }
}
