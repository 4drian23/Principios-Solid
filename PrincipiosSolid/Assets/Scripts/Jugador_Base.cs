using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Jugador_Base : MonoBehaviour
{
    [SerializeField] private Transform puntoDeSpawn;

    private Hechizo_Base spellCasteado;
    private Hechizo_Base spellPreparado;
    private ListaDeConjuros hechizosPreparados;
    private bool casteandoHechizo;

    void Start()
    {
        hechizosPreparados = this.GetComponent<ListaDeConjuros>();
        //Se obtiene una referencia de la lsita de conjuros para poder ejecutar sus metodos desde este script.
    }

    
    void Update()
    {
        LanzarConjuros();
        hechizosPreparados.PrepararConjuro();
    }

    private void LanzarConjuros()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {   
            if(casteandoHechizo == false) // si casteandoHechizo es verdadero precionar la tecla K no hara nada hasta que la variable sea falsa.
            {
                spellPreparado = hechizosPreparados.EntragarConjuroPreparado();
                //Se obtiene una referencia del hechizo preparado para castear.

                if(spellPreparado != null)
                {
                    casteandoHechizo = true;
                    spellCasteado = Instantiate(spellPreparado, puntoDeSpawn.position, puntoDeSpawn.rotation);
                    spellCasteado.transform.parent = puntoDeSpawn; //La isntacnia creada del hechizo se comvierte en hijo del objeto que proporciona la posicion para que se pueda mover junto al jugador.
                    StartCoroutine(DuracionDelHechizo(spellCasteado.DevolverDuracionDelHechizo()));
                    //Se inicia esta corrutina para que el hechizo desaparezca luego de un tiempo determinado.
                }
            }
            
        }
    }

    IEnumerator DuracionDelHechizo(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(spellCasteado.gameObject);
        casteandoHechizo = false;
        //Ahora que castenadoHechizo es falso, precioanr la tecla K creara una nueva instancia del hechizo que este preparado.
        Debug.Log("Finalizo el Hechizo");
    }
}
