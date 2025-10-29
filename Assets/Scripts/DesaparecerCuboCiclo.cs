using System.Collections;
using UnityEngine;

public class DesaparecerCuboCiclo : MonoBehaviour
{
    private float tiempoInvisible = 5f;
    private float timepoVisible = 3f;

    private Color[] secuenciaColor;
    private int indexColor = 0;

    private Renderer cubo;
    private bool agarrado = false;

    void Start()
    {
        cubo = GetComponent<Renderer>();

        secuenciaColor = new Color[]
        {
            Color.green,    
            Color.black,   
            Color.red,    
            Color.white,    
            Color.blue      
        };


        cubo.material.color = secuenciaColor[indexColor];


        StartCoroutine(CicloParpadeo());
    }

    public IEnumerator CicloParpadeo()
    {
        while (!agarrado)
        {

            cubo.enabled = true;
            yield return new WaitForSeconds(timepoVisible);


            cubo.enabled = false;
            yield return new WaitForSeconds(tiempoInvisible);

            indexColor = (indexColor + 1) % secuenciaColor.Length;
            cubo.material.color = secuenciaColor[indexColor];
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agarrado = true;
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }
}