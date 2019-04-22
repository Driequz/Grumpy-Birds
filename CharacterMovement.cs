using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float joyspeed;
    public float idlespeed;
    public float sadnessspeed;
   // public float surprisedspeed;

    ImageResultsParser userEmotions;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameController").transform;
        userEmotions = player.GetComponent<ImageResultsParser>();


    }

    // Update is called once per frame
    void Update()
    {

        float thresh = 10;

        if (userEmotions.joyLevel > thresh)
        {

            transform.Translate(Vector3.up * joyspeed * Time.deltaTime);

        }

        else if (userEmotions.sadnessLevel > thresh)
        {
            //setSad();
            transform.Translate(-Vector3.forward * sadnessspeed * Time.deltaTime);
        }

        //else if (userEmotions.surpriseLevel > thresh)
        //{
        //    //setSad();
        //    transform.Translate(-Vector3.back * surprisedspeed * Time.deltaTime);
        //}

        else
        {
            transform.Translate(Vector3.down * idlespeed * Time.deltaTime);
        }


    }
}
