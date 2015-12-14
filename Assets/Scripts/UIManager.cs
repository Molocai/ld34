using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    [Header("Elements d'interface")]
    public GameObject sliderGameObject;
    public GameObject scoreTextGameObject;

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
}
