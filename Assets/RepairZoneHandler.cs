using UnityEngine;
using System.Collections;

public class RepairZoneHandler : MonoBehaviour
{

    public GameObject[] particles;
    public float stopDuration;
    private float releaseTime = 0.0f;

    private GameObject cat;

    // Use this for initialization
    void Update()
    {
        if (Time.time >= releaseTime && releaseTime != 0)
        {
            cat.GetComponent<Rigidbody2D>().isKinematic = false;
            PlayerController.Get.activeRepairZone.SetActive(false);
            PlayerController.Get.activeRepairZone = null;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            cat = collision.gameObject;
            releaseTime = Time.time + stopDuration;
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            GameObject newParticles = (GameObject)Instantiate(particles[Random.Range(0, particles.Length - 1)] , transform.position, Quaternion.identity);
            newParticles.transform.SetParent(gameObject.transform);
        }
    }
}
