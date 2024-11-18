using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacadeClass : MonoBehaviour
{
    [SerializeField] private ListaDeConjuros listaDeHechizos;
    [SerializeField] private Movimiento move;
    private Hechizo_Base spellCasteado;
    private Hechizo_Base spellPreparado;
    
    private bool lanzandoHechizo;

    void Update()
    {
        listaDeHechizos.PrepararConjuro();
    }

    public  void LanzarConjuros(Transform puntoDeSpawn)
    {  
        if(lanzandoHechizo == false) // si lanzandoHechizo es verdadero precionar la tecla K no hara nada hasta que la variable sea falsa.
        {
            spellPreparado = listaDeHechizos.EntragarConjuroPreparado();
            //Se obtiene una referencia del hechizo preparado para castear.

            if(spellPreparado != null)
            {
                lanzandoHechizo = true;
                spellCasteado = Instantiate(spellPreparado, puntoDeSpawn.position, puntoDeSpawn.rotation);
                spellCasteado.transform.parent = puntoDeSpawn; //La isntacnia creada del hechizo se comvierte en hijo del objeto que proporciona la posicion para que se pueda mover junto al jugador.
                StartCoroutine(DuracionDelHechizo(spellCasteado.DevolverDuracionDelHechizo()));
                //Se inicia esta corrutina para que el hechizo desaparezca luego de un tiempo determinado.
            }
            else
            {
                Debug.Log("Ningun Hechizo preparado, preciona I o J");
            }
        } 
    }

    IEnumerator DuracionDelHechizo(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(spellCasteado.gameObject);
        lanzandoHechizo = false;
        //Ahora que castenadoHechizo es falso, precioanr la tecla K creara una nueva instancia del hechizo que este preparado.
        Debug.Log("Finalizo el Hechizo");
    }

    public void Movimiento(Jugador_Base jugador)
    {
        move.LogicaMovimiento(jugador);
    }
}
