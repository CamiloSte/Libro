using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    public static int Puntaje = 0;
    public string stringPuntaje = "Puntuacion";

    public Text TextPuntaje;

    public Puntuacion puntuacioncontroller;

    private void Awake()
    {
        puntuacioncontroller = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TextPuntaje !=null)
        {
            TextPuntaje.text = stringPuntaje + Puntaje.ToString();
        }
    }

}
