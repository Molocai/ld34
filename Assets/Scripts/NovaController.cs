using UnityEngine;
using System.Collections;

public class NovaController : MonoBehaviour
{

    public float initialMoveSpeed;
    public float speedboostFrequency;
    public float boostForce;
    public AudioClip audioPlayerDestruction;

    private Rigidbody2D body;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        body.AddForce(Vector2.right * initialMoveSpeed);

        StartCoroutine(PushNovaABit(speedboostFrequency));
    }

    IEnumerator PushNovaABit(float waitTime)
    {
        while (true)
        {
            body.AddForce(Vector2.right * boostForce);
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(audioPlayerDestruction);
            PlayerController.Get.Kill();
        }
    }
}
