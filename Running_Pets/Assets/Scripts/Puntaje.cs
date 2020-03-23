using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour {

    //main objects to find at this level
    public static Image image, image2, image3;
    //cookies count
    public static int galletas;
    //text to show how many cookies we have
    public Text numeroGalletas;
    //how many prices we have collected
    public static int premios;

	void Start () {
        premios = 0;
	}
	
	// Update is called once per frame
	void Update () {

        //if it is a level scene
        if(SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "GameOver") { 
        Sumar();

            }
	} 

    //draw prices depending on how many do we have
     public static void DibujarPremios()
     {
         if (Puntaje.premios == 1)
                 {
                     image = GameObject.Find("Premio1").GetComponent<Image>();
                     var tempColor = image.color;
                     tempColor.a = 255f;
                     image.color = tempColor;
                 }
                 else if (Puntaje.premios == 2)
                 {
                     image2 = GameObject.Find("Premio2").GetComponent<Image>();
                     var tempColor2 = image2.color;
                     tempColor2.a = 255f;
                     image2.color = tempColor2;
                 }
                 else if (Puntaje.premios == 3)
                 {
                     image3 = GameObject.Find("Premio3").GetComponent<Image>();
                     var tempColor3 = image3.color;
                     tempColor3.a = 255f;
                     image3.color = tempColor3;
                 }
     }

    //show how many cookies we have collected
    public void Sumar()
    {
        numeroGalletas.text = "X "+ galletas;
    }

    //save the number of cookies collected
    public void GuardarGalletas(string clave, int galleta)
    {
        PlayerPrefs.SetInt(clave, galleta);
    }

    //get the number of cookies saved
    public int RecuperaGalletas(string clave)
    {
        return PlayerPrefs.GetInt(clave);
    }
}
