using UnityEngine;

public class GalletaManager : MonoBehaviour {

    //rotation velocity
    public float degreesPerSec = 360f;
    
    
    void Update()
    {

        //calculate the rotation amount
        float rotAmount = degreesPerSec * Time.deltaTime;

        //get the current rotation
        float curRot = transform.localRotation.eulerAngles.z;

        //apply the rotation amoun to the current rotation
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
    }

    //if collision with the player
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            Destroy(this.gameObject);
        }
    }
}