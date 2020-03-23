using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resultados : MonoBehaviour
{

    //cookies number to show
    public int galletas = 0;
    //text to show the number of cookies
    public Text numeroGalletas;
    //number of cookies collected at last level played
    public int GalletasObtenidas;
    //number of gummy bears collected
    private int OsitosGanados;
    //gummy bear prefab
    public GameObject Osito1;
    //positions to instantiate the collected gummy bears
    public Transform LugarOsito1;
    public Transform LugarOsito2;
    public Transform LugarOsito3;


    void Start()
    {
        //get the collected cookies number
        GalletasObtenidas = PlayerPrefs.GetInt("Puntaje_Actual");
        //get the collected gummy bears number
        OsitosGanados = PlayerPrefs.GetInt("UltimosOsosGanados");

        StartCoroutine("MostrarResultadoOsos");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("MostrarResultado");
    }

    //load next level
    public void SiguienteNivel()
    {
        //load next scene if it wasn't the last one
        int sceneName = int.Parse(PlayerPrefs.GetString("lastLoadedScene"));
        if (sceneName < 10)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName + 01);
        }
        else  //load the levels scene if it was the final level
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Niveles");
        }
    }

    //Show the number of cookies collected
    IEnumerator MostrarResultado()
    {

        yield return new WaitForSeconds(1);
        if (GalletasObtenidas > galletas)
        {
            galletas++;
            numeroGalletas.text = "X " + galletas;
        }
    }

    //show how many gummy bears were collected
    IEnumerator MostrarResultadoOsos()
    {
        yield return new WaitForSeconds(1);
        switch (OsitosGanados) {
            case 1:
            Instantiate(Osito1, LugarOsito1.position, LugarOsito1.rotation);
                    break;
            case 2:
                Instantiate(Osito1, LugarOsito1.position, LugarOsito1.rotation);
                Instantiate(Osito1, LugarOsito2.position, LugarOsito2.rotation);
                break;
            case 3:
                Instantiate(Osito1, LugarOsito1.position, LugarOsito1.rotation);
                Instantiate(Osito1, LugarOsito2.position, LugarOsito2.rotation);
                Instantiate(Osito1, LugarOsito3.position, LugarOsito3.rotation);
                break;
        }
    }
}
