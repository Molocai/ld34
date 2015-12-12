using UnityEngine;
using System.Collections;

public class AsteroidBurstForce : MonoBehaviour {

    private Rigidbody2D body;

    [Header("Variables")]
    public float initialForce = 1.0f;
    public Vector3 target;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();

        Vector2 direction;
        direction = target - transform.position;
        direction.Normalize();

        body.AddForce(direction * initialForce);
    }
}
