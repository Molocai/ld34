using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroSound : MonoBehaviour {

    [Header("Son de l'intro")]

    public AudioClip Mireille;
    public AudioClip Roger;
    public AudioClip PopRoger;
    private AudioSource source;

    private bool notPopped = true;


    [Header("Temps Mireille")]
    public float mireilleDialogue = 10.0f;
    private bool lectureMireille = false;


    [Header("Temps Roger")]
    public float rogerDialogue = 4.0f;
    private bool lectureRoger = false;

    [Header("Temps phase jeu")]
    public float phaseJeu = 15.0f;

	public GameObject RogerPrefab;
	public GameObject RogerPosition;

	public GameObject MireillePrefab;
	public GameObject MireillePosition;

    private float relativeTime;


    // Use this for initialization
    void Start () {
        relativeTime = Time.time;
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Time.time > mireilleDialogue + relativeTime && lectureMireille == false)
        {
            source.PlayOneShot(Mireille, 1f);
            lectureMireille = true;
			Instantiate(MireillePrefab, MireillePosition.transform.position, Quaternion.identity);

        }

        if (Time.time > rogerDialogue + relativeTime && lectureRoger == false)
        {
            source.PlayOneShot(Roger, 1f);
            lectureRoger = true;
			Instantiate(RogerPrefab, RogerPosition.transform.position, Quaternion.identity);
        }

        if (Time.time > phaseJeu + relativeTime - 4.0f && notPopped)
        {
            source.PlayOneShot(PopRoger, 0.8f);
            notPopped = false;
        }

        if (Time.time > phaseJeu + relativeTime)
            SceneManager.LoadScene("testALL_Titouan");

    }


}













