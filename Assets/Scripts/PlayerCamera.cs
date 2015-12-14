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
        if (player == null)
            return;

        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
