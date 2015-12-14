using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    // Singleton
    #region Singleton
    static UIManager uimanager;
    public static UIManager Get
    {
        get
        {
            if (uimanager == null)
                uimanager = GameObject.FindObjectOfType<UIManager>();
            return uimanager;
        }
    }
    #endregion

    [Header("Elements d'interface")]
    public GameObject sliderGameObject;
    public GameObject scoreTextGameObject;
    public GameObject endScoreTextGameObject;
    public GameObject loseUIGameObject;
    public GameObject winUIGameObject;
    public GameObject winUIScore;

    private Slider spaceshipHealthSlider;
    private Text scoreText;
    private float w, h;

    void Start()
    {
        spaceshipHealthSlider = sliderGameObject.GetComponent<Slider>();
        scoreText = scoreTextGameObject.GetComponent<Text>();

        float sliderValue = (float)PlayerController.Get.spaceshipHealth / (float)PlayerController.Get.spaceshipMaxHealth;
        spaceshipHealthSlider.value = sliderValue;
    }

    void Update()
    {
        w = Screen.width;
        h = Screen.height;

        sliderGameObject.GetComponent<RectTransform>().position = new Vector3(6.0f * w / 7.0f, h / 10.0f, 0.5f);
        sliderGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(w / 8.0f, h / 15.0f);

        scoreTextGameObject.GetComponent<RectTransform>().position = new Vector3(5.0f * w / 7.0f, h / 10.0f, 0.5f);
        scoreTextGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(w / 8.0f, h / 15.0f);

        endScoreTextGameObject.GetComponent<RectTransform>().position = new Vector3(w / 2f, 1 * h / 3f, 0.5f);
        endScoreTextGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(w / 2f, 1 * h / 3f);

        scoreText.text = GameManager.Get.formatedScore;
    }
        void OnEnable()
    {
        PlayerController.OnPlayerChangeHealth += RefreshSlider;
    }

    void RefreshSlider(int life, int max)
    {
        float sliderValue = (float)life / (float)max;
        spaceshipHealthSlider.value = sliderValue;
    }

    public void HidePlayerInfos()
    {
        sliderGameObject.SetActive(false);
        scoreTextGameObject.SetActive(false);
        DisplayLoseScreen();
    }

    public void DisplayLoseScreen()
    {
        loseUIGameObject.SetActive(true);
    }

    public void DisplayWinScreen()
    {
        winUIGameObject.SetActive(true);
        winUIScore.GetComponent<Text>().text = GameManager.Get.formatedScore;
    }
}
