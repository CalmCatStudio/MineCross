using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour
{
    [SerializeField]
    private BoardController board = null;
    public BoardController Board { get { return board; } }
    [SerializeField]
    private LevelSettings settings = null;
    [SerializeField]
    private UIController UI = null;
    [SerializeField]
    private MemoPad memo = null;
    public MemoPad Memo { get { return memo; } }

    public bool IsGameOver { get; private set; } = false;
    public int PointsLeftOnBoard { get; set; } = 0;
    public int CurrentLevel { get; private set; } = 0;

    public void Init()
    {
        if (board == null || settings == null || UI == null || memo == null)
        {
            ErrorMessages.NullMessage(gameObject);
        }
        else
        {
            board.Init();
            CurrentLevel = 0;
        }
    }

    public void NewGame()
    {
        IsGameOver = false;
        PointsLeftOnBoard = board.StartNewGame(settings.NumberOfBombs + CurrentLevel);
        // Current level starts at 0; So we add 1 for the user to see the proper level
        UI.StartNextRound(CurrentLevel + 1);
    }

    public void GameOver()
    {
        IsGameOver = true;
        UI.EnableLoseCanvas();
    }

    public void WinGame()
    {
        IsGameOver = true;
        UI.EnableWinCanvas();
        CurrentLevel++;
    }
}
