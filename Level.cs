﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public enum LevelType
    {
        TIMER,
        OBSTACLE,
        MOVES,
    };

    public Grid grid;
    public HUD hud;

    public int score1Star;
    public int score2Star;
    public int score3Star;

    protected LevelType type;

    public LevelType Type
    {
        get { return type; }
    }

    protected int currentScore;

    protected bool didWin;

	// Use this for initialization
	void Start () {
        hud.SetScore(currentScore);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void GameWin()
    {
        grid.GameOver();
        didWin = true;
        StartCoroutine(WaitForGridFill());
    }

    public virtual void GameLose()
    {
        grid.GameOver();
        didWin = false;
        StartCoroutine(WaitForGridFill());
    }

    public virtual void OnMove()
    {

    }

    public virtual void OnPieceCleared(GamePiece piece)
    {
        //update score
        currentScore += piece.score;
        hud.SetScore(currentScore);
    }

    protected virtual IEnumerator WaitForGridFill()
    {
        yield return new WaitForSeconds(grid.fillTime);

        while (grid.IsFilling)
        {
            yield return new WaitForSeconds(grid.fillTime);
        }

        if (didWin)
        {
                hud.OnGameWin(currentScore);
        }
        else
        {
                hud.OnGameLose();
        }
    }

    public static IEnumerator Frames(int frameCount)
    {
        while (frameCount > 0)
        {
            frameCount--;
            yield return null;
        }
    }
}
