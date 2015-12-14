using UnityEngine;
using System.Collections;

public class CinematicSound : MonoBehaviour {
    public AudioClip sonCinematic;
    private AudioSource source;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
       source = GetComponent<AudioSource> ();
       source.PlayOneShot(sonCinematic, 1f);

}
	
	// Update is called once per frame
	void Update () {
	
	}

    
}
