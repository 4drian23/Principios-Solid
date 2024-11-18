using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class Hechizo_Base : MonoBehaviour
{
    [SerializeField] private float duracionDelHechizo;

    void Start()
    {
        LogicaDelHechizo();
    }

    protected virtual void LogicaDelHechizo()
    {
        this.GetComponentInChildren<ParticleSystem>().Play();
    }

    public float DevolverDuracionDelHechizo()
    {
        return duracionDelHechizo;
    }
}
