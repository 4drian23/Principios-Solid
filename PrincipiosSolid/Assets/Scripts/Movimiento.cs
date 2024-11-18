using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private int velocidadDeMovimiento;
    [SerializeField] private float velocidadDeRotacion;

    public void LogicaMovimiento(Jugador_Base jugador)
    {
        float hor = 0;
        float ver = 0;

        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");


        Vector3 direccionDeMovimiento = new Vector3(hor, 0, ver).normalized;

        direccionDeMovimiento = jugador.transform.TransformDirection(direccionDeMovimiento);

        jugador.transform.position += direccionDeMovimiento * velocidadDeMovimiento * Time.deltaTime;

        if(direccionDeMovimiento != Vector3.zero && hor < 0 || hor > 0)
        {
            jugador.transform.rotation = Quaternion.Slerp(jugador.transform.rotation, Quaternion.LookRotation(direccionDeMovimiento), velocidadDeRotacion * Time.deltaTime);
        }
    }
}
