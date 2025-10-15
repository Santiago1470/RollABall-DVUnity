using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CubeController : MonoBehaviour
{
    Material material;
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;
    public Slider scale;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RotarCubo()
    {
        transform.Rotate(new Vector3(45, 45, 45));
    }

    public void EscalarCubo(float value)
    {
        transform.localScale = new Vector3(value, value, value);
    }

    public void MoverCuboX(float value)
    {
        transform.localPosition = new Vector3(value, 1, 0);
    }

    public void MoverCuboY(float value)
    {
        transform.localPosition = new Vector3(0, value, 0);
    }

    public void MoverCuboZ(float value)
    {
        transform.localPosition = new Vector3(0, 1, value);
    }

    public void Reset()
    {
        transform.localPosition = new Vector3(0, 1, 0);
        transform.localScale = new Vector3(2, 2, 2);
        sliderX.value = 0;
        sliderY.value = 0;
        sliderZ.value = 0;
        scale.value = 2;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void CambiarColor(int opcion)
    {
        Debug.Log("Parametro: " + opcion);
        switch (opcion)
        {
            case 0:
                Debug.Log("Opcion 1");
                material.color = Color.black;
                break;
            case 1:
                Debug.Log("Opcion 2");
                material.color = Color.red;
                break;
            case 2:
                Debug.Log("Opcion 3");
                material.color = Color.yellow;
                break;
        }
    }

}