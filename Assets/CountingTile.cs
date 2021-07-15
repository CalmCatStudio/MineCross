using UnityEngine;

public class CountingTile : MonoBehaviour
{
    [SerializeField]
    private Sprite[] numbers = new Sprite[11];

    [SerializeField]
    private SpriteRenderer goodRenderer, badRenderer = null;

    public void Init(Tile[] tiles)
    {
        int goodTotal = 0;
        int bombTotal = 0;
        foreach (Tile tile in tiles)
        {
            goodTotal += (int)tile.Value;
            if (tile.Value == TileValue.Bomb)
            {
                bombTotal++;
            }
        }

        goodRenderer.sprite = numbers[goodTotal];
        badRenderer.sprite = numbers[bombTotal];
    }

}
