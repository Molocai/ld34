using UnityEngine;
using System.Collections;

public class Tmp : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Zob")
            Debug.Log("Touché!");
    }
}
