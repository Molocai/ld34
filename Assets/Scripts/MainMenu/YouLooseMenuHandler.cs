using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class YouLooseMenuHandler : MonoBehaviour {

    public string MainMenuToLoad;
    public string TryAgainToLoad;

    public void PlayMenu()
    {
        SceneManager.LoadScene(MainMenuToLoad);

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(TryAgainToLoad);

    }
}
