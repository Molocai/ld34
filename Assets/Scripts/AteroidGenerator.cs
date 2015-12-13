using UnityEngine;
using System.Collections;

public class AteroidGenerator : MonoBehaviour {

    [Header("Variables")]
    public GameObject asteroidPrefab;
    public float asteroidPopInterval;

    [Header("Zone d'apparition")]
    public float maxPopHeight;
    public float maxPopWidth;

    [Header("Zone de destination")]
    public GameObject destinationPoint;
    public float destinationHeight;
    public bool straightLine = false;

    [Header("Force des astéroïdes")]
    public float minForce = 0;
    public float maxForce;

    private float nextTime;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (nextTime <= 0)
            nextTime = Time.time + asteroidPopInterval;

        if (Time.time > nextTime)
        {
            nextTime = 0;

            // Random pop position
            Vector3 randomPos = new Vector3();
            randomPos.x = Random.Range(transform.position.x - maxPopWidth / 2, transform.position.x + maxPopWidth / 2);
            randomPos.y = Random.Range(transform.position.y - maxPopHeight / 2, transform.position.y + maxPopHeight / 2);
            randomPos.z = 7.5f;

            // Instantiate asteroid
            GameObject asteroid = (GameObject)GameObject.Instantiate(asteroidPrefab, randomPos, Quaternion.identity);
            AsteroidBurstForce burst = asteroid.GetComponent<AsteroidBurstForce>();

            // Random destination
            Vector3 randomTarget = new Vector3();
            randomTarget.x = destinationPoint.transform.position.x;
            if (straightLine)
                randomTarget.y = randomPos.y;
            else
                randomTarget.y = Random.Range(destinationPoint.transform.position.y - destinationHeight / 2, destinationPoint.transform.position.y + destinationHeight);

            // Initial burst
            burst.target = randomTarget;
            burst.initialForce = Random.Range(minForce, maxForce);

            // Set up autodestroy asteroid
            AsteroidAutoDestroy ad = asteroid.GetComponent<AsteroidAutoDestroy>();
            ad.referencePoint = randomPos;
            ad.maxDistance = Vector3.Distance(randomPos, randomTarget);
        }
    }

    void OnDrawGizmos()
    {
        // Swag gizmos
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(maxPopWidth, maxPopHeight));

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(destinationPoint.transform.position, new Vector3(1, destinationHeight));
    }
}
