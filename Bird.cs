using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;
    public bool isDead = false;

    private Rigidbody2D rb2d;
    private Animator anim;
    ImageResultsParser userEmotions;
    Transform bird;
    bool useFace = false;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bird = GameObject.FindGameObjectWithTag("bird").transform;
        useFace = GameObject.FindGameObjectWithTag("options").GetComponent<options>().faceControl;

        userEmotions = bird.GetComponent<ImageResultsParser>();
        Invoke("enableGravity", 2f);

    }

    // Update is called once per frame
    void Update()
    {
        float thresh = 0;

        if (isDead) { return; }

        if (!useFace)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
        else {
            print(userEmotions.joyLevel);
         if (userEmotions.joyLevel > thresh)
            {
                if (userEmotions.joyLevel > 1)
                {
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(0, upForce));
                    anim.SetTrigger("Flap");
                }

            }
        }
    }

    void OnCollisionEnter2D()
    {
        isDead = true;
        rb2d.velocity = Vector2.zero;
        anim.SetTrigger("Die");
        GameController.Instance.Die();
    }

    void enableGravity()
    {
        rb2d.gravityScale = 1;
    }
}
