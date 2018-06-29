using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    public Animator anim;


    //public float turnSpeed;

    //public Rigidbody2D rb;

    //int hele getallen, float kommagetallen.
    //public is aanpasbaar, private niet.

    void Start() {
    }
        

	
	void Update () {

        //if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < 0.5f )    //links = -1, rechts = 1
        //{
        //    transform.Translate(new Vector3 (Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
        //}

        //if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < 0.5f)    
        //{
        //    transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
        //}



        //animatie rotatie
        //combinatie tutorial en eigen code

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > .01f || horizontal < -.01f || vertical > .01f || vertical < -.01f)
        {
            transform.Translate(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, 0f, Space.World);
        }

        if (horizontal > 0.6f)  //rechts
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        if (horizontal < -0.6f)  //links
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 270f);
        }

        if (vertical > 0.6f)  //boven
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }

        if (vertical < -0.6f)  //beneden
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        anim.SetFloat("speed", Mathf.Abs (horizontal) + Mathf.Abs (vertical ));


        if ( ! (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("a"))) // snap ! niet maar het werkt
        {
            AudioSource audio = GetComponent<AudioSource>();    
            audio.Play();
        }







        //tutorial:

        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        //x,y,z vector 3. om frames in tijd om te zetten. z hoeft niet dus 0f(loat)
        // transform.Translate (horizontal * Time.deltaTime * speed , vertical * Time.deltaTime * speed , 0f);

        //laten draaien met loopricting mee over z as
        //transform.Translate(0f , vertical * Time.deltaTime * speed, 0f);
        //transform.Rotate(0f, 0f, horizontal * Time.deltaTime * turnSpeed);

        //rb.AddRelativeForce(new Vector2(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime));

        // = geeft niet de soort beweging die ik wil




    }

}