using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D body;

    [Header("Propulseurs")]
    public GameObject topThruster;
    public GameObject bottomThruster;

    [Header("Variables")]
    public float thrusterForce = 1.0f;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.AddForceAtPosition(transform.TransformDirection(1, 0.5f, 0) * thrusterForce, bottomThruster.transform.position);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            body.AddForceAtPosition(transform.TransformDirection(1, -0.5f, 0) * thrusterForce, topThruster.transform.position);
        }
    }
}
