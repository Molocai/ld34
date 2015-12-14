using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Cinematic : MonoBehaviour
{
    public MovieTexture movTexture;
    public string IntroNonPlayable;
    
    void Start ()
    {

        GetComponent<Renderer>().material.mainTexture = movTexture;
        movTexture.Play();
        StartCoroutine("waitForMovieEnd");
    }
    public void PlayIntro()
    {
        SceneManager.LoadScene(IntroNonPlayable);

    }



    IEnumerator waitForMovieEnd()
    {

        while (movTexture.isPlaying) // while the movie is playing
        {
            yield return new WaitForEndOfFrame();
        }
        // after movie is not playing / has stopped.
        onMovieEnded();
    }

    void onMovieEnded()
    {
        Debug.Log("Movie Ended!");
        PlayIntro();
       // Application.LoadLevel(1);
    }


}
