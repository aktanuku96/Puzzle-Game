using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour {

    public int scoreLimit;
    public Transform[] playerPositions;
    public GameObject[] players;
    public SnakeController[] playerScripts = new SnakeController[2];

    //public Text PlayerOneScore;
    //public Text PlayerTwoScore;

    public Text[] Scores;
    public Text GameOverText;

    //public int playerOneScoreCount;
    //public int playerTwoScoreCount;
    public int[] ScoreCounts = new int[2];


    private bool stall;
    // Use this for initialization
    void Start () {
        GameOverText.enabled = false;
        //playerOneScoreCount = 0;
        //playerTwoScoreCount = 0;

        playerScripts[0] = players[0].GetComponent<SnakeController>();
        playerScripts[1] = players[1].GetComponent<SnakeController>();


        Debug.Log(playerPositions[0].position);
        Debug.Log(playerPositions[1].position);
        players[0].transform.position = playerPositions[0].position;
        players[1].transform.position = playerPositions[1].position;

        Scores[0].text = "Player One: " + ScoreCounts[0].ToString();
        Scores[1].text = "Player Two: " + ScoreCounts[1].ToString();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(playerPositions[0].position);
        Debug.Log(playerPositions[1].position);
        Debug.Log("here is the transform 0: " + players[0].transform.position);
        Debug.Log("here is the transform 1: " + players[1].transform.position);

        Scores[0].text = "Player One: " + ScoreCounts[0].ToString();
        Scores[1].text = "Player Two: " + ScoreCounts[1].ToString();

        if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
        }

        //ScoreCounts[0].enabled = false;
        //ScoreCounts[1].enabled = false;
        if (stall) return;
        if (playerScripts[0].isHit || playerScripts[1].isHit)
        {
            if(playerScripts[0].isHit && playerScripts[1].isHit){
                //ScoreCounts[0].enabled = true;
                //ScoreCounts[1].enabled = true;
                ScoreCounts[0]++;
                ScoreCounts[1]++;
                //ScoreCounts[0].enabled = false;
                //ScoreCounts[1].enabled = false;
                //PlayerOneScore.text = "Player One: " + playerOneScoreCount.ToString();
                //PlayerTwoScore.text = "Player Two: " + playerTwoScoreCount.ToString();
            }

            else if(playerScripts[0].isHit){
                //ScoreCounts[1].enabled = true;
                ScoreCounts[1]++;
                //ScoreCounts[1].enabled = false;
                // PlayerTwoScore.text = "Player Two: " + playerTwoScoreCount.ToString();
            }

            else if(playerScripts[1].isHit){
                //ScoreCounts[0].enabled = true;
                ScoreCounts[0]++;
                //ScoreCounts[0].enabled = false;
                //PlayerOneScore.text = "Player One: " + playerOneScoreCount.ToString();
            }

            //Scores[0].enabled = true;
            //Scores[1].enabled = true;
            StartCoroutine(ResetRound());
        }
    }

    IEnumerator ResetRound(){
        Debug.Log("it started");
        stall = true;
        GameObject[] tailObjects = GameObject.FindGameObjectsWithTag("Tail");
        //Destroy(tailObjects[0]);
        //Destroy(tailObjects[1]);

        playerScripts[0].enabled = false;
        playerScripts[1].enabled = false;

        yield return new WaitForSeconds(2.5f);

        Debug.Log("The wait has ended");
        tailObjects = GameObject.FindGameObjectsWithTag("Tail");
        Debug.Log(tailObjects.Length);
        foreach (var tailObject in tailObjects)
        {
            //Debug.Log("destroying");
            Destroy(tailObject);
           //Debug.Log("destroying");
        }

        //Debug.Log(playerPositions[0].position);
        //Debug.Log(playerPositions[1].position);
        playerPositions[0].position = new Vector3(0.5f, 17.5f, 1.0f);
        playerPositions[1].position = new Vector3(28.5f, -0.5f, 1.0f);
        players[0].transform.position = playerPositions[0].position;
        players[1].transform.position = playerPositions[1].position;

        if(playerScripts[0].hitMoney || playerScripts[1].hitMoney){
            if(playerScripts[0].hitMoney && playerScripts[1].hitMoney){
                ScoreCounts[0] += 1000;
                ScoreCounts[1] += 1000;
            }
            else if(playerScripts[0].hitMoney){
                ScoreCounts[1] += 1000;
            }

            else if (playerScripts[1].hitMoney)
            {
                ScoreCounts[0] += 1000;
            }
        }

        if (ScoreCounts[0] >= scoreLimit || ScoreCounts[1] >= scoreLimit) {
            if (playerScripts[0].hitMoney || playerScripts[1].hitMoney){
                UnityEngine.SceneManagement.SceneManager.LoadScene("SternSuccess");
            }
            else{
                GameObject[] BlockObjects = GameObject.FindGameObjectsWithTag("Block");
                BlockObjects = GameObject.FindGameObjectsWithTag("Block");
                foreach (var BlockObject in BlockObjects)
                {
                    //Debug.Log("destroying");
                    Destroy(BlockObject);
                    //Debug.Log("destroying");
                }
                GameOverText.enabled = true;

                yield return new WaitForSeconds(4.0f);

                UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
            }

        }

        else{

            playerScripts[0].direction = Vector2.down;
            playerScripts[1].direction = Vector2.up;
            //players[0].transform.rotation = playerScripts[0].startPosition;
            //players[1].transform.rotation = playerScripts[1].startPosition;

            playerScripts[0].enabled = true;
            playerScripts[1].enabled = true;



            playerScripts[0].isHit = false;
            playerScripts[1].isHit = false;

            stall = false;
        }


    }

}
