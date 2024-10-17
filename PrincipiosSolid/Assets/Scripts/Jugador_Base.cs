using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Jugador_Base : MonoBehaviour
{
    [Header("SELECTOR DE CONJUROS")]
    [SerializeField] private GameObject conjuro1;
    [SerializeField] private GameObject conjuro2;
    [SerializeField] private GameObject conjuro3;
    [SerializeField] private Transform puntoDeSpawn;

    private GameObject conjuroCasteado;
    private GameObject conjuroPreparado;

    void Start()
    {
        conjuroPreparado = conjuro1;
    }

    
    void Update()
    {
        LanzarConjuros();
        CambiarDeConjuro();
    }

    private void LanzarConjuros()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            conjuroCasteado = Instantiate(conjuroPreparado, puntoDeSpawn.position, puntoDeSpawn.rotation);
            conjuroCasteado.GetComponentInChildren<ParticleSystem>().Play();
        }
    }

    private void CambiarDeConjuro()
    {
         if (Input.GetKeyDown(KeyCode.J))
        {
            Destroy(conjuroCasteado);
            conjuroPreparado = conjuro1;

        }
        else if(Input.GetKeyDown(KeyCode.I))
        {
            Destroy(conjuroCasteado);
            conjuroPreparado = conjuro2;
        }
        else if(Input.GetKeyDown(KeyCode.L))
        {
            Destroy(conjuroCasteado);
            conjuroPreparado = conjuro3;
        }
    }
}
