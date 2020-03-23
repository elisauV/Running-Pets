using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PremiosObtenidos : MonoBehaviour {

    //images of the prices of the level
    private Image image, image2, image3;
    //level gameobject
    public GameObject padre;
    //prize gameobject
    private GameObject premio1;
    private GameObject premio2;
    private GameObject premio3;
    //gameobject to lock the level
    private GameObject candado;
    //button to play level
    public Button boton;

    // Use this for initialization
    void Awake () {
        //find all the objects in the scene
        premio1 = padre.transform.Find("Premio1").gameObject;
        premio2 = padre.transform.Find("Premio2").gameObject;
        premio3 = padre.transform.Find("Premio3").gameObject;
        candado = GameObject.Find("candado"+padre.name);
    }

    private void Start()
    {

        if (PlayerPrefs.GetInt(padre.name) == 0 && int.Parse(padre.name) <10)
        {
            boton.interactable = false;
        }
        if (PlayerPrefs.GetInt(padre.name) > 0 && int.Parse(padre.name) < 10)
        {
            candado.SetActive(false);
        }
        if (PlayerPrefs.GetInt(padre.name) == 1)
        {
            image = premio1.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 255f;
            image.color = tempColor;
        }
        else if (PlayerPrefs.GetInt(padre.name) == 2)
        {
            image = premio1.GetComponent<Image>();
            image2 = premio2.GetComponent<Image>();
            var tempColor2 = image2.color;
            tempColor2.a = 255f;
            image.color = tempColor2;
            image2.color = tempColor2;
        }
        else if (PlayerPrefs.GetInt(padre.name) == 3)
        {
            image = premio1.GetComponent<Image>();
            image2 = premio2.GetComponent<Image>();
            image3 = premio3.GetComponent<Image>();
            var tempColor3 = image3.color;
            tempColor3.a = 255f;
            image.color = tempColor3;
            image2.color = tempColor3;
            image3.color = tempColor3;
        }
    }

}
