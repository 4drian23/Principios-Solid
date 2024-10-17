using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HechizoDeEvocacion : Hechizo_Base
{
    protected override void LogicaDelHechizo()
    {
        this.GetComponentInChildren<ParticleSystem>().Play();
        // Aca iria la logica para el daño que causan los hechizos de Evocacion (daño, otros efectos, etc.).
    }
}
