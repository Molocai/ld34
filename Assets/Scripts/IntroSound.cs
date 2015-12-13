using UnityEngine;
using System.Collections;

public class IntroSound : MonoBehaviour {

    [Header("Son de l'intro")]
    public AudioClip sonIntro;
    public AudioClip Mireille;
    public AudioClip Roger;
    private AudioSource source;

   
    [Header("Temps Mireille")]
    public float mireilleDialogue = 10.0f;
    private bool lectureMireille = false;


    [Header("Temps Roger")]
    public float rogerDialogue = 4.0f;
    private bool lectureRoger = false;


    // Use this for initialization
    void Start () {
        // source = GetComponent<AudioSource>();
        // source.PlayOneShot(sonIntro, 1f);

       

    }
	
	// Update is called once per frame
	void Update () {

        if (Time.time > mireilleDialogue && lectureMireille == false)
        {

            source = GetComponent<AudioSource>();
            source.PlayOneShot(Mireille, 1f);
            lectureMireille = true;


        }

        if (Time.time > rogerDialogue && lectureRoger == false)
        {

            source = GetComponent<AudioSource>();
            source.PlayOneShot(Roger, 1f);
            lectureRoger = true;
        }


    }


}













