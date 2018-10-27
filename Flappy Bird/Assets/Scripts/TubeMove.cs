using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeMove : MonoBehaviour {
    public GameObject tube;
    private int time=0;
    public AudioSource audioSource;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0.87f, Random.Range(-1.5f, 2.5f), -2.1596f);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        time += 1;
        GetComponent<Rigidbody2D>().velocity = Vector2.left * 3;
       
        if (time==300)
        {
            time = 0;
            Destroy(tube);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Untagged")
        {
            audioSource.Play();
            Time.timeScale = 0;
        }
    }
}
