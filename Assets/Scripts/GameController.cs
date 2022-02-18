using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameModel))]
public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameModel model = null;

    private void Awake()
    {
        if (model == null)
        {
            ErrorMessages.NullMessage(gameObject);
        }

        model.Init();
        StartNewGame();
    }

    public void Clicked(Vector2Int position)
    {
        if (!model.IsGameOver)
        {
            TileValue value = model.Board.TileClick(position, model.Memo.State);
            if (value == TileValue.Bomb)
            {
                model.GameOver();
            }
            else
            {
                if (value >= TileValue.Good)
                {
                    model.PointsLeftOnBoard--;

                    if (model.PointsLeftOnBoard == 0)
                    {
                        model.WinGame();
                    }
                }
            }
        }
    }

    public void RightClicked()
    {
        model.Memo.ToggleMemos();
    }

    public void StartNewGame()
    {
        model.NewGame();
    }

    public void RestartGame()
    {
        model.NewGame();
        model.LossPenalty();
    }
}
