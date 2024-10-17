using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private int velocidadDeMovimiento;
    [SerializeField] private float velocidadDeRotacion;

    void Start()
    {
        
    }

    void Update()
    {
        LogicaMovimiento();
    }

    private void LogicaMovimiento()
    {
        float hor = 0;
        float ver = 0;

        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");


        Vector3 direccionDeMovimiento = new Vector3(hor, 0, ver).normalized;

        direccionDeMovimiento = transform.TransformDirection(direccionDeMovimiento);

        this.transform.position += direccionDeMovimiento * velocidadDeMovimiento * Time.deltaTime;

        if(direccionDeMovimiento != Vector3.zero && hor < 0 || hor > 0)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direccionDeMovimiento), velocidadDeRotacion * Time.deltaTime);
        }
    }
}
