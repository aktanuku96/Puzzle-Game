using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour {

    // Use this for initialization
    Vector2 direction = Vector2.down;
    bool movePOne = false;
    bool movePTwo = false;

    public GameObject PlayerOnePreFab;
    public GameObject PlayerTwoPreFab;

    List<Transform> tailOne = new List<Transform>();

	void Start () {
        InvokeRepeating("Move", 0.02f, 0.02f);
	}
	
	// Update is called once per frame
	void Update () {
        

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


        //if(gameObject.tag.Equals("PlayerOne")){
        //    Vector2 v = transform.position;
        //     GameObject g = (GameObject)Instantiate(PlayerOnePreFab, v, Quaternion.identity);
        //     tailOne.Insert(0, g.transform);
        //    if(tailOne.Count > 0){
        //        tailOne.Last().position = v;
        //        tailOne.Insert(0, tailOne.Last());
        //    }
        //}

        if(Input.GetKey(KeyCode.R)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
        }
    }

    void Move()
    {
        Vector2 v = transform.position;
       // GameObject g = (GameObject)Instantiate(PlayerOnePreFab, v, Quaternion.identity);
       // tailOne.Insert(0, g.transform);
        transform.Translate(direction * Time.deltaTime *2) ;
        //if(tailOne.Count > 0){
        //    tailOne.Last().position = v;
        //    tailOne.Insert(0, tailOne.Last());
        //}
    }

    void OnCollisionEnter(Collision collision)
    {
        //CancelInvoke();
        Debug.Log("Hi");
        //if(collision.gameObject.tag.Equals("Wall"))
        //CancelInvoke();
        if (collision.gameObject.tag.Equals("Wall"))
        {
            Debug.Log("HITTTTT THE WALLL");
            CancelInvoke();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Wall")){
            Debug.Log("HITTTTT THE WALLL");
            CancelInvoke();
        }
    }

}
