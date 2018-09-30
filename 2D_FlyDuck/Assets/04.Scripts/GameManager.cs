using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1024, 600, true);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
