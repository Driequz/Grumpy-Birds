using UnityEngine;
using System.Collections;

public class FacialExpressions : MonoBehaviour
{

    //Script containing levels of emotions
    ImageResultsParser userEmotions;

    //player Transform used to obtain reference to UserEmotions script
    Transform player;

    //Used to change the face from smiling to frowning
    public Renderer faceRenderer;


    private Material faceMaterial;
    private Vector2 uvOffset;
    private Animator animator;


    // Initialization and Setting references
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameController").transform;
        userEmotions = player.GetComponent<ImageResultsParser>();
        uvOffset = Vector2.zero;
        faceMaterial = faceRenderer.materials[1];

    }


    // Setting the user's dominant emotion every frame
    void Update()
    {

        float thresh = 10;
        float Sthresh = 20;
        faceMaterial.SetTextureOffset("_MainTex", uvOffset);


        //the Update() method finds the dominant emotion and calls the appropriate method to set the emotion on the character.
        //Therefore, you must get the emotions of joy and sadness from the public variables in the ImageResultsParser class. 

        //If the dominant emotion is less than some threshold, such as 40 (it is on a scale from 0-100), 
        //then it is not strong enough so just set the character to be idle.

        //psuedo



        if (userEmotions.joyLevel > thresh)
        {

            setJoyful();

        }

        //else if (userEmotions.surpriseLevel > Sthresh)
        //{
        //    setSurprise();
        //}

        else if (userEmotions.sadnessLevel > thresh)
        {
            setSad();
        }

        else
        {
            setIdle();

        }


        // TODO for Question 2
    }

    //sets the Character's emotion to Idle (Emotionless)
    void setIdle()
    {

        // TODO for Question 2

        uvOffset = new Vector2(0, 0);
    }

    //sets the Character's emotion to Joyful (Smiling)
    void setJoyful()
    {
        //   
        // TODO for Question 2

        uvOffset = new Vector2(0.2f, 0);


    }

    //sets the Character's emotion to Sad (Frowning)
    void setSad()
    {

        // TODO for Question 2

        uvOffset = new Vector2(0, -0.25f);
    }

    void setSurprise()
    {

        // TODO for Question 2

        uvOffset = new Vector2(-0.1f, 0);
    }
}