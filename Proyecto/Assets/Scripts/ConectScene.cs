using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConectScene : MonoBehaviour
{

    public void cambiarEscena(string Nombre)
    {
        SceneManager.LoadScene(Nombre);
        print("cambiando a la escena" + Nombre);
        SceneManager.LoadScene(Nombre);
    }
}
