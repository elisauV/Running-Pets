using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour {

    //characters images
    private GameObject imagenGatito;
    private GameObject imagenPerrito;

    //characters prefabs
    private GameObject personajeGatito;
    private GameObject personajePerrito;

    //command buttons for each character
    private GameObject botonesGatito;
    private GameObject botonesPerrito;

    //string to be use for make kitty selected by default
    string personajeElegido = "gatito";

    //audios for play when select character and level
    public AudioSource PersonajeElegido;
    public AudioSource NivelElegido;

    //background image
    public AudioSource MusicaDeFondo;

    public void Awake()
    {
        //play background music
        MusicaDeFondo.Play();
        
        //if it is a level scene
        if (SceneManager.GetActiveScene().name != "Menu" && 
            SceneManager.GetActiveScene().name != "GameOver" &&
            SceneManager.GetActiveScene().name != "Niveles" && 
            SceneManager.GetActiveScene().name != "Resultado")
        {
            //find the character and the buttons
            personajeGatito = GameObject.Find("Gatito");
            botonesGatito = GameObject.Find("botonesGatito");
            personajePerrito = GameObject.Find("Perrito");
            botonesPerrito = GameObject.Find("botonesPerrito");
            activarPersonaje();
        }

        //if it is menu scene
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            //select the cat by default
            PlayerPrefs.SetString(personajeElegido, "gatito");
            imagenGatito = GameObject.Find("img_Gatito");
            imagenPerrito = GameObject.Find("img_Perrito");
            imagenPerrito.SetActive(false);
        }

        //if game over scene
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            //show the selected character image 
            imagenGatito = GameObject.Find("GatitoDead");
            imagenPerrito = GameObject.Find("PerritoDead");
            if (PlayerPrefs.GetString(personajeElegido) == "gatito") { 
                
            imagenPerrito.SetActive(false);
            }
            else
            {
                imagenGatito.SetActive(false);
            }
        }
    }
    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            //if is allready a character selected, show it
            if (RecuperaElegido() != null)
            {
                cambiarImagen();
            }
        }
    }

    //load last scene to play it again
    public void Reintentar()
    {
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(sceneName);
    }

    //stop background music
    public void pararMusica()
    {
        // if it is playing stop it
        if (MusicaDeFondo.isPlaying)
        {
            MusicaDeFondo.Stop();
        }
        else
        {
            MusicaDeFondo.Play();
        }
    }

    //show the selected character image
    public void cambiarImagen()
    {
            if (RecuperaElegido() == "gatito")
            {
                imagenGatito.SetActive(true);
                imagenPerrito.SetActive(false);
            }
            if (RecuperaElegido() == "perrito")
            {
                imagenGatito.SetActive(false);
                imagenPerrito.SetActive(true);
            }
    }

    //enable the character selected and it's controllers
    public void activarPersonaje()
    {
        //habilita el personaje elegido en la escena
        if (RecuperaElegido() == "perrito")
        {
            personajeGatito.SetActive(false);
            botonesGatito.SetActive(false);
            //perrito.SetActive(true);
        }
        else
        {
            personajePerrito.SetActive(false);
            botonesPerrito.SetActive(false);
        }
    }

    //quit application
    public void Salir()
    {
        Application.Quit();
    }

    //scene selection
    public void Elegir(string a)
    {
        NivelElegido.Play();
        StartCoroutine(ComenzarNivel(a));
    }

    //wait for the scene to be load
    IEnumerator ComenzarNivel(string a)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(a);
    }

    //load winning scene
    public void Ganado()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //save character selection
    public void ElegirPersonaje(string eleccion)
    {
        PersonajeElegido.Play();
        PlayerPrefs.SetString(personajeElegido, eleccion);  
    }

    //get the previous selected character
    public string RecuperaElegido()
    {
        return PlayerPrefs.GetString(personajeElegido);
    }
}
