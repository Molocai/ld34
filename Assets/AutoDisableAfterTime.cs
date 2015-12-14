using UnityEngine;
using System.Collections;

public class AutoDisableAfterTime : MonoBehaviour {

    public float duration;
    private float startTime;
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= startTime + duration)
            gameObject.SetActive(false);
	}

    void OnEnable()
    {
        startTime = Time.time;
    }
}
