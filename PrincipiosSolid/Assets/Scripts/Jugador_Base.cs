using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public  class Jugador_Base : MonoBehaviour
{
    [SerializeField] private Transform puntoDeSpawn;
    [SerializeField] private FacadeClass fachada;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            fachada.LanzarConjuros(puntoDeSpawn);
        }
        
        fachada.Movimiento(this);

        //Las acciones que se necesite que el jugador pueda realizar son invocadas por medio de la clase "FacadeClass"
        //De esta forma este jugador puede acceder al lanzamiento de conjuros y al movimiento
        //Se pueden seguir creando mas clases y lo unico que hay que hacer es modificar el codigo de la clase "FacadeClass"
        //Se pueden crear varias instancias de esta clase u otras diferente pero que requieran utilizar todas o algunas de las acciones creadas
        
    }

    
}
