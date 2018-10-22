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

    private int triggerCount;
    private bool isHit;

    private int pauseCount;
    private int playerOneScoreCount;
    private int playerTwoScoreCount;


    List<Transform> tailOne = new List<Transform>();

	void Start () {
        //InvokeRepeating("Move", 0.02f, 0.02f);
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

        if (count % 50 == 0)
        {
            Move();
           
        }


        if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
        }
    }

    void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(direction * speed);
       // GameObject g = (GameObject)Instantiate(PlayerOnePreFab, v, Quaternion.identity);
        //tailOne.Insert(0, g.transform);

        //if(tailOne.Count > 0){
        //    tailOne.Last().position = v;

        //    tailOne.Insert(0, tailOne.Last());
        //    tailOne.RemoveAt(tailOne.Count - 1);
        //}
      
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
        if (other.gameObject.tag.Equals("PlayerTwo") && gameObject.tag.Equals("PlayerOne"))
        {
            Debug.Log("HITTTTT THE WALLL");
            transform.Translate(direction * speed);
            speed = 0;
            playerOneScoreCount++;
            SetPointsText();
        }
        if (other.gameObject.tag.Equals("PlayerOne") && gameObject.tag.Equals("PlayerOne"))
        {
            Debug.Log("HITTTTT THE WALLL");
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
