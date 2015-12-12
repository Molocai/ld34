using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour
{

    public Vector3 velocity;

    private Rigidbody2D body;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = body.velocity;
        velocity *= 2;
    }
}
