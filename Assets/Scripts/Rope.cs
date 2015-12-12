using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour
{
    public GameObject link, cat;
    public int nbLinks;
    public float scLink;

    private GameObject[] tabLink;

	void Start ()
    {
        tabLink = new GameObject[nbLinks];

        link.transform.localScale = new Vector3(scLink, scLink, 1.0f);
	    for (int i = 0; i < nbLinks; i++)
        {
            GameObject tmp = Instantiate(link, new Vector3(link.transform.position.x, link.transform.position.y - i * (scLink/2.0f), link.transform.position.z), Quaternion.identity) as GameObject;
            tmp.transform.parent = transform;
            tabLink[i] = tmp;

            if (i == 0)
            {
                link.GetComponent<DistanceJoint2D>().connectedBody = tmp.GetComponent<Rigidbody2D>();
            }
            else tabLink[i - 1].GetComponent<DistanceJoint2D>().connectedBody = tmp.GetComponent<Rigidbody2D>();
        }
        link.GetComponent<Rigidbody2D>().isKinematic = true;
        tabLink[nbLinks-1].GetComponent<DistanceJoint2D>().connectedBody = cat.GetComponent<Rigidbody2D>();

    }
	void Update ()
    {
	    
	}
}
