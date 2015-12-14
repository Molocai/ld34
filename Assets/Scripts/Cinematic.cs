using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Cinematic : MonoBehaviour
{
    //public Animation cinematicSprite;
    private float currentTime, spriteLenght = 12.1f;

    void Start()
    {
        currentTime = Time.time;
        //cinematicSprite = GetComponent<Animation>();
        //StartCoroutine("waitForMovieEnd");
    }
    void Update()
    {
        if (Time.time >= currentTime + spriteLenght)
            PlayIntro();
    }
    /*
    IEnumerator waitForMovieEnd()
    {
        while (cinematicSprite.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        onMovieEnded();
    }
    void onMovieEnded()
    {
        Debug.Log("Movie Ended!");
        PlayIntro();
    }*/
    public void PlayIntro()
    {
        SceneManager.LoadScene("IntroNonPlayable");
    }
}
