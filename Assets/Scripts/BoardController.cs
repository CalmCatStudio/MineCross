using UnityEngine;

[RequireComponent(typeof(BoardModel))]
public class BoardController : MonoBehaviour
{
    [SerializeField]
    private BoardModel model = null;

    public void Init()
    {
        if (model == null)
        {
            ErrorMessages.NullMessage(gameObject);
        }
        else
        {
            model.Init();
        }
    }

    public int StartNewGame(int numberOfBombs)
    {
        return model.NewGame(numberOfBombs);
    }

    public TileValue TileClick(Vector2Int position, MemoState memo)
    {
        Tile tile = model.Tiles[position.x, position.y];

        if (memo == MemoState.None)
        {
            return tile.Clicked();
        }
        else
        {
            if (memo != MemoState.None)
            {
                tile.MemoClick(memo);
            }
            return TileValue.Empty;
        }
    }
}
