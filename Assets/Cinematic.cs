using UnityEngine;
using System.Collections;

public class Cinematic : MonoBehaviour {
public AudioClip cinematic;
public MovieTexture movTexture;

	// Use this for initialization
	void Start () {

        GetComponent<Renderer>().material.mainTexture = movTexture;
        movTexture.Play();


    }
	

	// Update is called once per frame
	void Update () {
	
	}
}
