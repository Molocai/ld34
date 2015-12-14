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

	// Use this for initialization
	void OnEnable () {
        activateTime = Time.time;

        if (type == ENDSCREENTYPE.WIN)
            Destroy(PlayerController.Get.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
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
