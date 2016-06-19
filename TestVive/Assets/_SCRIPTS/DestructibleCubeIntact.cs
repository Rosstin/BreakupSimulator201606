using UnityEngine;
using System.Collections;

public class DestructibleCubeIntact : MonoBehaviour {
    public Rigidbody myRigidBody;

    private Vector3 lastFrameVelocity;

    public static float BREAK_SPEED = 1.3f;

    // Use this for initialization
    void Start () {
        myRigidBody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if(lastFrameVelocity != null) {
            print(lastFrameVelocity.magnitude - myRigidBody.velocity.magnitude);

            if ( lastFrameVelocity.magnitude - myRigidBody.velocity.magnitude  >= BREAK_SPEED )
            {
                Debug.Log("break time");
                replaceWithBroken();
            }

        }
        lastFrameVelocity = myRigidBody.velocity;
    }

    void replaceWithBroken()
    {
        this.gameObject.SetActive(false);
        GameObject myDestroyedCube;
        myDestroyedCube = Instantiate(Resources.Load("DestructibleCubeBroken"), transform.position, transform.rotation) as GameObject;
        myDestroyedCube.transform.localScale = this.transform.localScale;
        myDestroyedCube.GetComponent<DestructibleCubeBroken>().explode();

        Destroy(gameObject);
    }
}
