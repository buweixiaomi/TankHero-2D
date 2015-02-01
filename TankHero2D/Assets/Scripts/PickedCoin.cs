﻿using UnityEngine;
using System.Collections;

public class PickedCoin : MonoBehaviour {

    private bool picked;

    void Awake()
    {
        this.picked = false;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != Tags.hero) { return; }

        if (!this.picked)
        {
            this.picked = true;
            MonoBehaviour.Destroy(this.gameObject);
        }
    }
}
