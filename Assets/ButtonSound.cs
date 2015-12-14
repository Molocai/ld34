using UnityEngine;
using System.Collections;



public class ButtonSound : MonoBehaviour {

	public AudioClip BoutonPlay;
	public AudioClip BoutonTryAgain;
	public AudioClip OpeningMenu;

	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		source.PlayOneShot(BoutonPlay, 1f);
	}
}
