using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoretext;
    int myscore;
    public Text balltext;
    int ballscore = 3;
    public static UIManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject);
        }
        else
        {
           // Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = myscore.ToString();
        balltext.text ="X" + ballscore.ToString();
    }

    public void AddScore(int score)
    {
        myscore = myscore + score;

    }
    public void ballscoree()
    {
        ballscore = ballscore + 1;
    }

}
