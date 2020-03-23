using UnityEngine;

public class Camara : MonoBehaviour {

    //camera game
    private Transform cam;
    //player
    private GameObject player;
    // Use this for initialization
    void Start () {

        cam = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

        //make the camera move with the player on the x axis
        cam.position = new Vector2(player.transform.position.x, 0);
	}
}
