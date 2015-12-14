using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndScreenController : MonoBehaviour {

    public enum ENDSCREENTYPE
    {
        LOSE,
        WIN
    }

    public ENDSCREENTYPE type;
    public float timeBeforeActivation;
    public GameObject scoreTextObject;
    private float activateTime;
    private AudioSource[] audios;
    private AudioSource mAudio;
    private bool isStarting = true;

    // Use this for initialization
    void OnEnable () {
        activateTime = Time.time;

        if (type == ENDSCREENTYPE.WIN)
        {
            Destroy(PlayerController.Get.gameObject);

            //AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            //foreach (AudioSource aud in audios)
            //    aud.volume = 0.0f;
            //AudioSource mAudio = GetComponent<AudioSource>();
            //mAudio.volume = 1.0f;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (type == ENDSCREENTYPE.WIN && isStarting)
        {
            audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource aud in audios)
                aud.volume = Mathf.Lerp(aud.volume, 0.0f, Time.deltaTime * 0.8f);
            mAudio = GetComponent<AudioSource>();
            mAudio.volume = 1.0f;

            isStarting = false;
        }

        if (Time.time >= activateTime + timeBeforeActivation)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                SceneManager.LoadScene("mainMenu");
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                SceneManager.LoadScene("testALL_Titouan");
            }
        }
    }
}
