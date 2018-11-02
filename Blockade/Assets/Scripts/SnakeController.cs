using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour {

    // Use this for initialization
    Vector2 direction;

    //public float speedOne;
    //public float speedTwo;
    public float speed;

    public GameObject PlayerOnePreFab;
    public int count;
    public Text PlayerOneScore;
    public Text PlayerTwoScore;
    public bool isHit;

    public AudioClip sound;
    public AudioSource aud;

    private Vector2 pos;
    private int playerOneScoreCount;
    private int playerTwoScoreCount;



	void Start () {

        playerOneScoreCount = 0;
        playerTwoScoreCount = 0;

        aud.clip = sound;


        isHit = false;
        //Debug.Log("Is it Hit? : " + isHit + " " + gameObject.name);
        if(gameObject.tag.Equals("PlayerOne")){
            direction = Vector2.down;

        }
        else if (gameObject.tag.Equals("PlayerTwo"))
        {
            direction = Vector2.up;

        }
    }

    // Update is called once per frame
    void Update () {

        count += 1;

        if (Input.GetKey(KeyCode.S) && gameObject.tag.Equals("PlayerOne"))
            direction = Vector2.down;
        else if (Input.GetKey(KeyCode.W) && gameObject.tag.Equals("PlayerOne"))
            direction = Vector2.up;
        else if (Input.GetKey(KeyCode.A) && gameObject.tag.Equals("PlayerOne"))
            direction = Vector2.left;
        else if (Input.GetKey(KeyCode.D) && gameObject.tag.Equals("PlayerOne"))
            direction = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow) && gameObject.tag.Equals("PlayerTwo"))
            direction = Vector2.down;
        else if (Input.GetKey(KeyCode.UpArrow) && gameObject.tag.Equals("PlayerTwo"))
            direction = Vector2.up;
        else if (Input.GetKey(KeyCode.LeftArrow) && gameObject.tag.Equals("PlayerTwo"))
            direction = Vector2.left;
        else if (Input.GetKey(KeyCode.RightArrow) && gameObject.tag.Equals("PlayerTwo"))
            direction = Vector2.right;

        if (count % 10 == 0)
        {
            pos = transform.position;
            if(isHit == false){

                Move();
                //Instantiate(PlayerOnePreFab, pos, transform.rotation);
            }

            else{
                Debug.Log("hi");
                //Stop();
            }

            //else{
                //if(gameObject.tag.Equals("PlayerOne") || gameObject.tag.Equals("PlayerTwo"))
                //{
                //    speed = 0;
                //}
               
                //Debug.Log("all should stop");
            //}
           
        }


        if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
        }
    }

    void Move()
    {
        aud.PlayOneShot(sound);

    
        transform.position += (Vector3)(direction);
        Instantiate(PlayerOnePreFab, pos, transform.rotation);
        

       
        //if ((gameObject.name == "PlayerOne" && isHit == false))
        //{
        //    transform.position += (Vector3)(direction);
        //    Instantiate(PlayerOnePreFab, pos, transform.rotation);
        //}

        //else if((gameObject.name == "PlayerTwo" && isHit == false)){
        //    transform.position += (Vector3)(direction);
        //    Instantiate(PlayerOnePreFab, pos, transform.rotation);
        //}
    }

    //void Stop(){

    //    if (gameObject.name == "PlayerOne")
    //    {
    //       // Debug.Log("hiii");
    //        transform.position += (Vector3)(direction * 0);
    //    }

    //    if ((gameObject.name == "PlayerTwo"))
    //    {
    //        transform.position += (Vector3)(direction * 0);
           
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log(other.gameObject.tag);
       // Debug.Log(gameObject.tag);
        isHit = true;
        SetPointsText();
        //speed = 0;

        if(other.gameObject.tag.Equals("Tail")){
            Debug.Log("I HIT THE TAIL");
        }
        //Debug.Log("Is it hit? : " + isHit + " " + gameObject.name);
        //speed = 0;
        //if (other.gameObject.tag.Equals("Wall")){
        //    //speed = 0;
        //    speedOne = 0;
        //    speedTwo = 0;
        //    if (gameObject.tag.Equals("PlayerOne")){
        //        //Debug.Log("HITTTTT THE WALLL");
        //        //transform.Translate(direction * speed);
        //        //speedOne = 0;
        //        //speedTwo = 0;
        //        playerTwoScoreCount++;
        //        SetPointsText();
        //    }

        //    if(gameObject.tag.Equals("PlayerTwo"))
        //    {
        //        //Debug.Log("HITTTTT THE WALLL");
        //        // transform.Translate(direction * speed);
        //        //speedOne = 0;
        //        //speedTwo = 0;
        //        playerOneScoreCount++;
        //        SetPointsText();

        //    }
           
        //}
        ////else if (other.gameObject.tag.Equals("Wall") && )
        ////{
           
        ////}
        //else if (other.gameObject.tag.Equals("Tail"))
        //{
        //    if(gameObject.tag.Equals("PlayerOne")){
        //        //Debug.Log("I hit player one");
        //        //transform.Translate(direction * speed);
        //        speedOne = 0;
        //        speedTwo = 0;
        //        playerTwoScoreCount++;
        //        SetPointsText();
        //    }

        //    else if(gameObject.tag.Equals("PlayerTwo")){
        //        // Debug.Log("I hit player two");
        //        //transform.Translate(direction * speed);
        //        speedOne = 0;
        //        speedTwo = 0;
        //        playerOneScoreCount++;
        //        SetPointsText();
        //    }
           
        //}

        //else if(other.gameObject.tag.Equals("PlayerOne")){
        //    // Debug.Log("I hit player one");
        //    //transform.Translate(direction * speed);
        //    speedOne = 0;
        //    speedTwo = 0;
        //    playerTwoScoreCount++;
        //    SetPointsText();
        //}

        //else if (other.gameObject.tag.Equals("PlayerTwo"))
        //{
        //    // Debug.Log("I hit player one");
        //    //transform.Translate(direction * speed);
        //    speedOne = 0;
        //    speedTwo = 0;
        //    playerOneScoreCount++;
        //    SetPointsText();
        //}



    }

    void SetPointsText()
    {
        if (gameObject.tag.Equals("PlayerOne"))
        {
            playerTwoScoreCount++;
            PlayerTwoScore.text = "Player Two: " + playerTwoScoreCount.ToString();
        }
        else if (gameObject.tag.Equals("PlayerTwo")) {
            playerOneScoreCount++;
            PlayerOneScore.text = "Player One: " + playerOneScoreCount.ToString();
        }
        //Debug.Log(GameObject.name);
        if(gameObject.tag.Equals("PlayerOne")){
            //transform.position = new Vector3(-1.295f, 0.775001f, 0f);
        }
        if (gameObject.tag.Equals("PlayerTwo")){
          //  transform.position = new Vector3(-1.035015f, 0.755015f, 0f);
        }
       
                
    }

}
