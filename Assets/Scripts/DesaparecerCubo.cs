using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DesaparecerCubo : MonoBehaviour
{
    private float tiempoDesaparicion = 10f;

    void Start()
    {
        StartCoroutine(Desaparecer());
    }

    void Update()
    {
        
    }

    public IEnumerator Desaparecer()
    {
        yield return new WaitForSeconds(tiempoDesaparicion);
        gameObject.SetActive(false);
    }
    
}