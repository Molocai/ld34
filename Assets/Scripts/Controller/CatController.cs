using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour
{
    private Rigidbody2D body;

    public float tempsEntreRogerMiaou;
    private float nextMiaou = 0.0f;
    public float magnitudeMiaou = 1.5f;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float magnitude = body.velocity.magnitude;

        if (Time.time >= nextMiaou && magnitude >= magnitudeMiaou)
        {
            PlayerController.Get.ps.RogerTracte(magnitude);
            nextMiaou = Time.time + tempsEntreRogerMiaou;
        }
    }
}
