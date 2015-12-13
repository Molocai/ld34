using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSound : MonoBehaviour {

	[Header("Sons des alertes")]
	public AudioClip AlerteNiveau1;
	public AudioClip AlerteNiveau1bis;
	public AudioClip AlerteNiveau2;
	public AudioClip AlerteNiveau3;
	public AudioClip AlerteNiveau4;

	[Header("Sons des Asteroides")]
	public List<AudioClip> AsteroidAleatoire;
    AudioClip LastUsedAsteroidSound;
	AudioClip AsteroidSound;

	[Header("Sons des Réparations")]
	public List<AudioClip> ReparationAleatoire;
    AudioClip LastUsedReparationSound;
	AudioClip ReparationSound;

    [Header("Sons de Roger tracté")]
	public List<AudioClip> RogerSoundAleatoire;
    AudioClip LastUsedRogerSound;
	AudioClip RogerSound;

    private AudioSource source;

	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
	}


	public void Alertes(int spaceshipHealth)
	{
		if (spaceshipHealth == 9 || spaceshipHealth == 7 )
		{
			source.PlayOneShot(AlerteNiveau1,1f);
		}
		if (spaceshipHealth == 8)
		{
			source.PlayOneShot(AlerteNiveau1bis,1f);
		}
		if (spaceshipHealth == 6 || spaceshipHealth == 5 )
		{
			source.PlayOneShot(AlerteNiveau2,1f);
		}
		if (spaceshipHealth == 4 || spaceshipHealth == 3 )
		{
			source.PlayOneShot(AlerteNiveau3,1f);
		}
		if (spaceshipHealth == 2 || spaceshipHealth == 1 )
		{
			source.PlayOneShot(AlerteNiveau4,1f);
		}
	}
	public void ImpactAsteroidSound()
	{
        do
        {
            AsteroidSound = AsteroidAleatoire[Random.Range(0, AsteroidAleatoire.Count)];
        } while (AsteroidSound == LastUsedAsteroidSound);

        LastUsedAsteroidSound = AsteroidSound;

		source.PlayOneShot(AsteroidSound,1f);
    }

	public void ReparationSoundAleatoire()
	{
        do
        {
            ReparationSound = ReparationAleatoire[Random.Range(0, ReparationAleatoire.Count)];
        } while (ReparationSound == LastUsedReparationSound);

        LastUsedReparationSound = ReparationSound;

        source.PlayOneShot(ReparationSound,1f);
	}

	public void RogerTracte(float vitesseRoger)
	{
        do
        {
            RogerSound = RogerSoundAleatoire[Random.Range(0, RogerSoundAleatoire.Count)];
        } while (RogerSound == LastUsedRogerSound);

        LastUsedRogerSound = RogerSound;

        source.PlayOneShot(RogerSound,1f);
	}


}
