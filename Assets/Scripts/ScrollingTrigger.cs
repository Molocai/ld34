using UnityEngine;
using System.Collections;

public class ScrollingTrigger : MonoBehaviour
{
    public bool left, right, activated = true;
    public GameObject toD;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            if (activated && left)
            {
                GameObject space = Instantiate(toD, new Vector3(toD.transform.position.x - 16.0f, toD.transform.position.y, toD.transform.position.z), Quaternion.identity) as GameObject;
                
                activated = false;
            }
            else if (activated && right)
            {
                GameObject space = Instantiate(toD, new Vector3(toD.transform.position.x + 16.0f, toD.transform.position.y, toD.transform.position.z), Quaternion.identity) as GameObject;
                activated = false;
            }
        }
    }
    void OnDrawGizmos()
    {
        Color giz = Color.yellow;
        giz.a = 0.5f;
        Gizmos.color = giz;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
