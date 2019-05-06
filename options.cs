using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    public bool faceControl;
    // Start is called before the first frame update
    void Start()
    {
        faceControl = false;
        DontDestroyOnLoad(this);
    }

    public void withFaceControl(bool answer)
    {
        faceControl = answer;
        SceneManager.LoadScene(0);
    }

    public void withoutFaceControl(bool answer)
    {
        faceControl = answer;
        SceneManager.LoadScene(0);
    }
}
