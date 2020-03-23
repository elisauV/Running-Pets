using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour {

    //for detect if it is paused
    public static bool JuegoEnPausa = false;

    //pause gui buttons
    public GameObject MenuPausaUI;
    
	void Update () {

        // pause/unpause button
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (JuegoEnPausa)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
         }
	}

    //when pause reduce to 0 the game timescale
    public void Pausa()
    {
        MenuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        JuegoEnPausa = true;
    }

    //unpause to reactivate the speed
    public void Reanudar()
    {
        MenuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        JuegoEnPausa = false;
    }

    //load menu scene
    public void CargarMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    //quit the game
    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
