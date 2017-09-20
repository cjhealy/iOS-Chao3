using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    public Level level;
    public GameOver gameOver;

    public UnityEngine.UI.Text remainingText;
    public UnityEngine.UI.Text remainingSubtext;
    public UnityEngine.UI.Text targetText;
    public UnityEngine.UI.Text targetSubtext;
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Image[] stars;

    private int starIDx = 0;

    // Use this for initialization
    void Start () {
		for(int i = 0; i < stars.Length; i++)
        {
            if (i == starIDx)
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();

        int visibleStar = 0;

        if (score >= level.score1Star && score < level.score2Star)
        {
            visibleStar = 1;
        }
        else if (score >= level.score2Star && score < level.score3Star)
        {
            visibleStar = 2;
        }
        else if (score >= level.score3Star)
        {
            visibleStar = 3;
        }

        for (int i = 0; i < stars.Length; i++)
        {
            if (i == visibleStar)
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }

        starIDx = visibleStar;
    }

    public void SetTarget(int target)
    {
        targetText.text = target.ToString();
    }

    public void SetRemaining(int remaining)
    {
        remainingText.text = remaining.ToString();
    }

    public void SetRemaining(string remaining) //takes in the remaining TIME which is formatting in a string
    {
        remainingText.text = remaining;
    }

    public void SetLevelType(Level.LevelType type)
    {
        if (type == Level.LevelType.MOVES)
        {
            remainingSubtext.text = "moves";
            targetSubtext.text = "target score";
        }
        else if (type == Level.LevelType.OBSTACLE)
        {
            remainingSubtext.text = "moves";
            targetSubtext.text = "obstacles remaining";
        }
        else if (type == Level.LevelType.TIMER)
        {
            remainingSubtext.text = "time";
            targetSubtext.text = "target score";
        }
    }

    public void OnGameWin(int score)
    {
        gameOver.ShowWin(score, starIDx);
        if (starIDx > PlayerPrefs.GetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, 0))
        {
            PlayerPrefs.SetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, starIDx);
        }
    }

    public void OnGameLose()
    {
        gameOver.ShowLose();
    }
}
