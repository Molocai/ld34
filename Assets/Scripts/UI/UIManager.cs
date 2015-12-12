using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    [Header("Elements d'interface")]
    public GameObject sliderGameObject;

    private Slider spaceshipHealthSlider;

    void Start()
    {
        spaceshipHealthSlider = sliderGameObject.GetComponent<Slider>();
    }

    void OnEnable()
    {
        PlayerController.OnPlayerGetHit += OnPlayerGetHit;
    }

    void OnPlayerGetHit(int life, int max)
    {
        float sliderValue = (float)life / (float)max;
        Debug.Log("Life: " + life + " max: " + max + " slider: " + sliderValue.ToString());
        spaceshipHealthSlider.value = sliderValue;
    }
}
