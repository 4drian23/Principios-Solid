using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaDeConjuros : MonoBehaviour
{
    [Header("Lista de Hechizos")]
    [SerializeField] private Hechizo_Base spell_1;
    [SerializeField] private Hechizo_Base spell_2;
    //Por aca se proporcionan las referencias de los hechizos, los cuales serian prefabs con el script del tipo de hechizo que le corresponda.
    //Cada tipo de hechizo hereda de Conjura_Base, por lo cual, para agregar mas hechizos solo hay que extender esta parte del codigo.

    private Hechizo_Base spellPreparado;
    
    public Hechizo_Base EntragarConjuroPreparado()
    {
        return spellPreparado;
    }

    public void PrepararConjuro()
    {
        //Este metodo se llama en el metodo Update de la clase Jugador_Base, cada input cambia el valor de spellPreparado por un hechizo diferente,
        //de esta forma se puede cambiar de hechizo en cualquier momento. Se podira utilizar un array y una sola tecla para cambiar de hechizos, de esta forma
        //solo abria que crear un metodo que agregue los  hechizos al array y recorra la lista. De esta forma se evita crear una enorme cadena de else if para 
        //agregar mas hechizos. No lo hago por que se me ocurrio recien.

        if (Input.GetKeyDown(KeyCode.J))
        {
            spellPreparado = spell_1;
            Debug.Log("Hechizo 1 preparado");

        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            spellPreparado = spell_2;
            Debug.Log("Hechizo 2 preparado");
        }
     }
}
