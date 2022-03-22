using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //textmeshpro...

public class NpcFala : MonoBehaviour
{
    // Start is called before the first frame update
    [TextArea]
    public List<string> conversa;
    public int indiceConversa = 0;

    [Header("Referencia de objetos")]
    public TextMeshProUGUI text_fala;
    public GameObject go_fala;

    [Header("Quanto tempo cada fala fica na tela")]
    public float falaTimerMax;
    private float falaTimer;

    [Header("Tempo entre uma fala aparecer e a outra")]
    public float esperaTimerMax;
    private float esperaTimer;

    private bool comecarFala;

    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        comecarFala = false;
        indiceConversa = 0;
        text_fala.text = conversa[indiceConversa];
        go_fala.SetActive(false);

        falaTimer = falaTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,player.position) < 1.5f)
        {
            comecarFala = true;
        }

        if (comecarFala)
        {
            if (falaTimer < 0)
            {
                indiceConversa++;

                if (indiceConversa > conversa.Count - 1)
                {
                    indiceConversa = 0;
                    comecarFala = false;
                }
                esperaTimer = esperaTimerMax;
                falaTimer = falaTimerMax;
            }
            else
            {
                falaTimer -= Time.deltaTime;
            }


            if (esperaTimer >= 0)
            {
                esperaTimer -= Time.deltaTime;

                if (go_fala.activeInHierarchy)
                    go_fala.SetActive(false);
            }
            else
            {
                if (!go_fala.activeInHierarchy)
                {
                    go_fala.SetActive(true);
                    text_fala.text = conversa[indiceConversa];
                }
            }
        }
    }
}
