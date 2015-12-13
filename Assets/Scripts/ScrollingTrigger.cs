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
                Instantiate(toD, new Vector3(toD.transform.position.x - 16.0f, toD.transform.position.y, toD.transform.position.z), Quaternion.identity);
                
                activated = false;
            }
            else if (activated && right)
            {
                Instantiate(toD, new Vector3(toD.transform.position.x + 16.0f, toD.transform.position.y, toD.transform.position.z), Quaternion.identity);
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
