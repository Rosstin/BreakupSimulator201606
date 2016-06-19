using UnityEngine;
using System.Collections;

public class DestructibleCubeBroken : MonoBehaviour {

    public GameObject[] pieces;

    public static float EXPLOSION_MAGNITUDE = 1.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void explode()
    {
        foreach (GameObject piece in pieces )
        {
            float randomValue = Random.value;
            Vector3 randomDirection = new Vector3(Random.value, Random.value, Random.value);

            Rigidbody myRigidBody = piece.GetComponent<Rigidbody>();

            /*
            float power = 10.0f * randomValue;
            float radius = 5.0f * randomValue;
            Vector3 explosionPosition = gameObject.transform.position;

            piece.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPosition, radius);
            */

            myRigidBody.AddForce( randomDirection * randomValue * 100.0f  );

            piece.GetComponent<MeshRenderer>().material.color = new Color(1.0f-randomValue*0.5f, 1.0f-randomValue*0.3f, 1.0f-randomValue*0.1f);
        }
    }
}
