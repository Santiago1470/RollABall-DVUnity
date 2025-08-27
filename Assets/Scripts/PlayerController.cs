using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform particulas;
    private ParticleSystem systemParticulas;
    private Vector3 posicion;
    public float speed;
    private Rigidbody rb;

    void Start()
    {
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
            other.gameObject.SetActive(false);
            // systemParticulas.Play();
        }
        else
        {

        }
    }
}
