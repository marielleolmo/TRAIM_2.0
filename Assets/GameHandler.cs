using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    private static GameHandler _singleton;

    public static GameHandler Singleton
    {
        get => _singleton;

        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(GameHandler)} instance already exists, destroying duplicate!");
                Destroy(value);
            }

        }
    }

    [SerializeField] private float MaxTime = 30;
    private float Timer = 0;
    public int Score = 0;
    public bool isPlaying = false;
    public TMP_Text ScoreText;
    public TMP_Text TimerText;

    private void Awake()
    {
        Singleton = this;
    }

    public void Play()
    {
        Timer = MaxTime;
        Score = 0;
        isPlaying = true;
    }

    private void Update()
    {
        Debug.Log(Timer);
        if (isPlaying)
        {
            Timer -= Time.deltaTime;
            TimerText.text = Timer.ToString("F2");

            if (Timer <= 0)
            {
                Timer = 0;
                isPlaying = false;
            }
        }

        if (!isPlaying)
            TimerText.text = "Shoot Cube to Start";

        ScoreText.text = "Score: " + Score.ToString();

        /*
         
        //reducing my in game timer to 2 decimal places

        1st attempt

        string s = Timer.ToString();        //make timer to string and store in local variable
        char C = '\0';                      //make char with empty character
        for (int i = 0; i < 5; i++)         //make for loop that iterates 5x
        {
            C += s[i];                      //add string index of i to our char
        }

        TimerText.text = C.ToString();      //set TimerText to the char that we turned into a string 
        
         


        2nd attempt

        string s = Timer.ToString();
        s = (s[0] + s[1] + s[2] + s[3] + s[4]).ToString();
        TimerText.text = s;
        
        */

        

    }   

}
