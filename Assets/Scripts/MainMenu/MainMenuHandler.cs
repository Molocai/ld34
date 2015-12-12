using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour {

    public string sceneNameToLoad;

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
