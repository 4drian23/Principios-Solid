using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HehizoDeConjuracion : Hechizo_Base
{
    protected override void LogicaDelHechizo()
    {
        this.GetComponentInChildren<ParticleSystem>().Play();
        // Aca iria la logica para los efectos que causan los hechizos de Conjuracion (daño, otros efectos, etc.).
    }
}
