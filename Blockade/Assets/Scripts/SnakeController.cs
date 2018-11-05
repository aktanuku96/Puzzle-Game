using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour {

    // Use this for initialization
    public Vector2 direction;

   //public float speed;

    public GameObject PlayerOnePreFab;
    public int count;

    public bool isHit;

    public AudioClip sound;
    public AudioSource aud;

    private Vector2 pos;
   
	void Start () {

        aud.clip = sound;

        isHit = false;

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
            }

        }

    }

    void Move()
    {
        aud.PlayOneShot(sound);

        transform.position += (Vector3)(direction);
        Instantiate(PlayerOnePreFab, pos, transform.rotation);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log(other.gameObject.tag);
       // Debug.Log(gameObject.tag);
        isHit = true;

        //speed = 0;

    }

   

}
