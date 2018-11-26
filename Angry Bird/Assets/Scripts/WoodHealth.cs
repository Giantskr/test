using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodHealth : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip destroy;
    public int woodHeath=500;
    private bool destroyed=false;
    private int beforeDestroy=0;
    // Start is called before the first frame update
    void Start()
    {
         GetComponent<Animator>().SetFloat("Hp",woodHeath);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetFloat("Hp", woodHeath);
        if (woodHeath < 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            beforeDestroy += 1;
            if (destroyed == false)
            {
                audioSource.PlayOneShot(destroy);
                destroyed = true;
            }
            
           if(beforeDestroy>100)
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        double damage = Math.Sqrt(collision.relativeVelocity.x * collision.relativeVelocity.x + collision.relativeVelocity.y * collision.relativeVelocity.y);
        //audioSource.PlayOneShot(collisionSound);
        int damagE = (int)damage;
        if(damagE>3)
        {
            audioSource.Play();
            
        }

        woodHeath = woodHeath-10*damagE ;
        // Debug.Log(woodHeath);
    }
}
