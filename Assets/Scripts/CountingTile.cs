using UnityEngine;

public class CountingTile : MonoBehaviour
{
    [SerializeField]
    private Sprite[] numbers = new Sprite[11];

    [SerializeField]
    private SpriteRenderer pointRenderer = null, badRenderer = null;

    public void Init(Tile[] tiles)
    {
        int pointTotal = 0;
        int bombTotal = 0;
        foreach (Tile tile in tiles)
        {
            pointTotal += (int)tile.Value;
            if (tile.Value == TileValue.Bomb)
            {
                bombTotal++;
            }
        }

        pointRenderer.sprite = numbers[pointTotal];
        badRenderer.sprite = numbers[bombTotal];
    }
}
