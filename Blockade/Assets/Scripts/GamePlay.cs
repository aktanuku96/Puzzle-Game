using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour {

    public int scoreLimit;
    public Transform[] playerPositions;
    public GameObject[] players;
    public SnakeController[] playerScripts = new SnakeController[2];

	// Use this for initialization
	void Start () {

        playerScripts[0] = players[0].GetComponent<SnakeController>();
        playerScripts[1] = players[1].GetComponent<SnakeController>();

        players[0].transform.position = playerPositions[0].position;
        players[1].transform.position = playerPositions[1].position;
	}
	
	// Update is called once per frame
	void Update () {
        if(playerScripts[0].isHit || playerScripts[1].isHit){
            playerScripts[0].enabled = false;
            playerScripts[1].enabled = false;
        }
        if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
        }
    }
}
