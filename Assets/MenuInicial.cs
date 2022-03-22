using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [Header("Nome da cena inicial")]
    public string nomecena_inicial = "SampleScene";

    public void Jogar()
    {
        SceneManager.LoadScene(nomecena_inicial);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
