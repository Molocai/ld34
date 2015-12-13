using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
	void Start ()
    {

	
	}
	void Update ()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
