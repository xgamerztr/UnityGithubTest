using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerUp : MonoBehaviour
{

    public Text startText;

    // Start is called before the first frame update
    void Start()
    {
        startText.text = ("Time Passed:");
    }

    // Update is called once per frame
    void Update()
    {
        startText.text = ("Time Passed: " + Time.fixedTime );

       
    }

   
}
