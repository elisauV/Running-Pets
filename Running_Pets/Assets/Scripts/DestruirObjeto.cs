using UnityEngine;

public class DestruirObjeto : MonoBehaviour {

	
    void OnCollisionEnter(Collision col)
    {
        //if collides with the player
        if (col.collider.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
        }
    }
}
