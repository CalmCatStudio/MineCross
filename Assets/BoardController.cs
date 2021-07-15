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
        model.Tiles[position.x, position.y].Clicked(memo);
        if (memo == MemoState.None)
        {
            return model.Tiles[position.x, position.y].Value;
        }
        else
        {
            return TileValue.Empty;
        }
    }
}
