﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparo : MonoBehaviour
{
    public GameObject Player;
    public float TiempoEntreDisparos = 1f;
    public float rango = 100f;

    float timer;

    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    LineRenderer gunLine;
    Light gunLight;
    float effectsDisplayTime = 1.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= TiempoEntreDisparos * effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
    }

    void Shoot()
    {
        Vector3 ubicacion = new Vector3(Player.transform.position.x,
            Player.transform.position.y + 1.1f,
            Player.transform.position.z);
        timer = 0f;
        gunLine.enabled = true;
        gunLight.enabled = true;
        shootRay.origin = ubicacion;
        shootRay.direction = transform.forward;
        gunLine.SetPosition(0, ubicacion);
        if (Physics.Raycast(shootRay, out shootHit, rango, shootableMask))
        {
            Destroy(shootHit.collider.gameObject);
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {

            Debug.Log("No se impacto con ningun objeto");
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * rango);
        }
    }

    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }
    
}
