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

    // Use this for initialization
    void OnEnable () {
        activateTime = Time.time;

        if (type == ENDSCREENTYPE.WIN)
            Destroy(PlayerController.Get.gameObject);
    }
	
	void Update () {

        if (type == ENDSCREENTYPE.WIN)
        {
            audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource aud in audios)
                aud.volume = Mathf.Lerp(aud.volume, 0.0f, Time.deltaTime * 0.8f);
            mAudio = GetComponent<AudioSource>();
            mAudio.volume = 1.0f;
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
