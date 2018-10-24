using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour {

    // Use this for initialization
    Vector2 direction = Vector2.down;

    public float speed;
    public GameObject PlayerOnePreFab;
    public int count;
    public Text PlayerOneScore;
    public Text PlayerTwoScore;
    private Vector2 pos;
    private int triggerCount;
    private bool isHit;

    private int pauseCount;
    private int playerOneScoreCount;
    private int playerTwoScoreCount;


    List<Transform> tailOne = new List<Transform>();

	void Start () {
        //Vector2 pos = transform.position;
        //PlayerOneScore= GetComponent<Text>();
        //PlayerTwoScore= GetComponent<Text>();
        playerOneScoreCount = 0;
        playerTwoScoreCount = 0;
       // pauseCount = 0;
        //StartCoroutine(BlinkText());
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

        if (count % 30 == 0)
        {
            pos = transform.position;
            Move();
           //Debug.Log(pos);
            Instantiate(PlayerOnePreFab, pos, transform.rotation);
        }


        if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
        }
    }

    void Move()
    {

        transform.Translate(direction * speed);
      
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Wall") && gameObject.tag.Equals("PlayerOne")){
            Debug.Log("HITTTTT THE WALLL");
            transform.Translate(direction * speed);
            speed = 0;
            playerOneScoreCount++;
            SetPointsText();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Wall") && gameObject.tag.Equals("PlayerTwo")){
            Debug.Log("HITTTTT THE WALLL");
            transform.Translate(direction*speed);
            speed = 0;
            playerOneScoreCount++;
            SetPointsText();
            //UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
        }
        if (other.gameObject.tag.Equals("Wall") && gameObject.tag.Equals("PlayerOne"))
        {
            Debug.Log("HITTTTT THE WALLL");
            transform.Translate(direction * speed);
            speed = 0;
            playerTwoScoreCount++;
            SetPointsText();
        }
        if (gameObject.tag.Equals("PlayerTwo") && other.gameObject.tag.Equals("Tail"))
        {
            Debug.Log("I hit player one");
            transform.Translate(direction * speed);
            speed = 0;
            playerOneScoreCount++;
            SetPointsText();
        }
        if (gameObject.tag.Equals("PlayerOne") && other.gameObject.tag.Equals("Tail"))
        {
            Debug.Log("I hit player two");
            transform.Translate(direction * speed);
            speed = 0;
            playerTwoScoreCount++;
            SetPointsText();
        }


    }

    void SetPointsText()
    {
        PlayerOneScore.text = playerOneScoreCount.ToString();
        PlayerTwoScore.text = playerTwoScoreCount.ToString();
      
    }

    //public IEnumerator BlinkText(){
    //    while(true){
    //        PlayerOneScore.text = "" + playerOneScoreCount;
    //        yield return new WaitForSeconds(.5f);
    //        PlayerTwoScore.text = "" + playerTwoScoreCount;
    //        yield return new WaitForSeconds(.5f);
    //    }
    //}

}
