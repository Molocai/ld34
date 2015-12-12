using UnityEngine;
using System.Collections;

public class AsteroidAutoDestroy : MonoBehaviour {

    public Vector3 referencePoint;
    public float maxDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Vector3.Distance(referencePoint, transform.position) > maxDistance)
        {
            Destroy(gameObject);
        }
	}
}
