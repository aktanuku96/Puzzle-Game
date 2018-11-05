using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour {

    public Text Stern;
    public AudioClip hiss;
    public AudioSource source;
	// Use this for initialization
	void Start () {
        source.clip = hiss;
	}
	
	// Update is called once per frame
	void Update () {
        Stern.enabled = true;
        source.PlayOneShot(hiss);
        if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
        }

    }
}
