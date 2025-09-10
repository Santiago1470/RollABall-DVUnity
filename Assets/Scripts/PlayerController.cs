using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Transform particulas;
    private ParticleSystem systemParticulas;
    private Vector3 posicion;
    public float speed;
    private Rigidbody rb;
    private int contador;
    public TextMeshProUGUI textoContador;
    private AudioSource audioRecoleccion;

    void Start()
    {
        audioRecoleccion = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        systemParticulas = particulas.GetComponent<ParticleSystem>();
        systemParticulas.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // float moveJump = Input.GetAxis("Jump");
        // float high = 0;
        // if(moveJump) {
        //     high = 5;
        // }
        // Debug.Log(moveJump);
        Vector3 movimiento = new Vector3(moveHorizontal * speed, 0.0f, moveVertical * speed);

        rb.AddForce(movimiento);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Recolectable"))
        {
            audioRecoleccion.Play();
            contador += 1;
            posicion = other.gameObject.transform.position;
            particulas.position = posicion;
            systemParticulas = particulas.GetComponent<ParticleSystem>();

            systemParticulas.Play();
            other.gameObject.SetActive(false);
            textoContador.text = "Objetos recolectados: " + contador.ToString();
            if (contador == 12)
            {
                Debug.Log(contador);
                SceneManager.LoadScene(1);
            }
        }
        else
        {

        }
        
    }
}
