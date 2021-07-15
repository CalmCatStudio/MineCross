using UnityEngine;

[RequireComponent(typeof(TileView))]
public class Tile : MonoBehaviour
{
    [SerializeField]
    private TileView view = null;

    public TileValue Value { get; private set; }
    private bool isRevealed = false;

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
            isRevealed = false;
        }
    }

    public void Clicked(MemoState memo)
    {
        if (!isRevealed)
        {
            switch (memo)
            {
                case MemoState.None:
                    view.RevealTile();
                    isRevealed = true;
                    break;
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
