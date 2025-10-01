using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSalir : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SalirAplicacion()
    {
        // Debug.Log("Saliendo de la app.");
        // Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
