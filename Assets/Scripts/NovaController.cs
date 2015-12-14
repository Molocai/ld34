using UnityEngine;
using System.Collections;

public class NovaController : MonoBehaviour {

    public float initialMoveSpeed;
    public float speedboostFrequency;
    public float boostForce;

    private Rigidbody2D body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();

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
}
