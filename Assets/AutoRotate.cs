﻿using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour {

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

        rb.AddTorque(Random.Range(0, 5));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
