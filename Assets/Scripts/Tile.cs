using UnityEngine;

[RequireComponent(typeof(TileView))]
public class Tile : MonoBehaviour
{
    [SerializeField]
    private TileView view = null;

    public TileValue Value { get; private set; }
    public bool IsRevealed { get; private set; } = false;

    public void Init(TileValue tileValue)
    {
        Value = tileValue;

        if (view == null)
        {
            ErrorMessages.NullMessage(gameObject);
        }
        else
        {
            view.Init(Value);
            IsRevealed = false;
        }
    }

    public TileValue Clicked()
    {
        if (!IsRevealed)
        {
            view.RevealTile();
            IsRevealed = true;
            return Value;
        }
        else
        {
            return TileValue.Empty;
        }
    }

    public void MemoClick(MemoState memo)
    {
        if (!IsRevealed)
        {
            switch (memo)
            {
                case MemoState.Empty:
                    view.ToggleEmptyMemo();
                    break;
                case MemoState.Cross:
                    view.ToggleCrossMemo();
                    break;
                case MemoState.Both:
                    view.ToggleBothMemos();
                    break;
                default:
                    Debug.LogError("The Tile was not given a proper Memostate");
                    break;
            }
        }
    }
}

public enum TileValue
{
    Bomb,
    Empty,
    Good,
    Best
}
