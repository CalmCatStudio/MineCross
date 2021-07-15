using UnityEngine;
using CalmCatExtensions.Shuffle;

public class BoardModel : MonoBehaviour
{
    [SerializeField]
    private Tile[] tiles = new Tile[9];
    public Tile[,] Tiles { get; private set; }

    [SerializeField]
    private CountingTile[] rowCountingTiles = new CountingTile[5];
    [SerializeField]
    private CountingTile[] columnCountingTiles = new CountingTile[5];

    [SerializeField]
    private Vector2Int boardSize = new Vector2Int(5, 5);

    public void Init()
    {
        if (tiles == null)
        {
            ErrorMessages.NullMessage(gameObject);
        }
        else
        {
            Tiles = ConvertArrayTo2DArray(tiles, boardSize);
        }
    }

    public int NewGame(int numberOfBombs)
    {
        int totalPoints = SetTileValues(numberOfBombs);
        CountRows();
        CountColumns();

        return totalPoints;
    }

    private void CountColumns()
    {
        for (int i = 0; i < columnCountingTiles.Length; i++)
        {
            columnCountingTiles[i].Init(ReturnColumn(i));
        }
    }

    private void CountRows()
    {
        for (int i = 0; i < rowCountingTiles.Length; i++)
        {
            rowCountingTiles[i].Init(ReturnRow(i));
        }
    }

    public Tile[] ReturnColumn(int columnToReturn)
    {
        Tile[] column = new Tile[boardSize.y];

        for (int i = 0; i < boardSize.y; i++)
        {
            column[i] = (Tiles[columnToReturn, i]);
        }

        return column;        
    }

    public Tile[] ReturnRow(int rowToReturn)
    {
        Tile[] row = new Tile[boardSize.x];

        for (int i = 0; i < boardSize.x; i++)
        {
            row[i] = (Tiles[i, rowToReturn]);
        }

        return row;
    }

    /// <summary>
    /// This method sets up the tile values, and tries to add some randomness to the game.
    /// It returns the total points needed to win the game as an Int.
    /// </summary>
    private int SetTileValues(int numberOfBombs)
    {
        // Get the count of tiles
        int totalCount = tiles.Length;
        int currentCount = totalCount;
        // Get the number of bombs
        int bombCount = numberOfBombs;
        // Subtract the number of bombs from the count
        currentCount -= bombCount;
        // Cut the remaining count into two halves
        int emptyCount = currentCount / 2;
        int goodCount = emptyCount;
        // Integer division can lose information So if that happens we add 1 to fix it
        if ((emptyCount + goodCount) + bombCount != totalCount)
        {
            emptyCount++;
        }

        // Subtract a small random number from the good count, and add it to the empty Count
        int random = Random.Range(1, 4);
        goodCount -= random;
        emptyCount += random;

        random = Random.Range(1, 4);
        goodCount -= random;
        int bestCount = random;

        int combinedGoodPoints = bestCount + goodCount;

        // Debugging line
        print($"Bomb Count: {bombCount} | Empty Count: {emptyCount} | Good Count: {goodCount} | Best Count: {bestCount} | TotalCount: {bombCount + emptyCount + goodCount + bestCount}");

        // We now have three numbers that total the number of tiles
        // bombs, empty, good
        // add each item to the values array
        TileValue[] values = new TileValue[totalCount];
        for (int i = 0; i < totalCount; i++)
        {
            if (bombCount != 0)
            {
                values[i] = TileValue.Bomb;
                bombCount--;
            }
            else if (emptyCount != 0)
            {
                values[i] = TileValue.Empty;
                emptyCount--;
            }
            else if (goodCount != 0)
            {
                values[i] = TileValue.Good;
                goodCount--;
            }
            else
            {
                values[i] = TileValue.Best;
            }
        }

        // Shuffle the array
        values.Shuffle();

        for (int i = 0; i < totalCount; i++)
        {
            tiles[i].Init(values[i]);            
        }

        return combinedGoodPoints;
    }

    private T[,] ConvertArrayTo2DArray<T>(T[] tiles, Vector2Int size)
    {
        T[,] boardAs2DArray = new T[size.x, size.y];

        int i = 0;
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                boardAs2DArray[y, x] = tiles[i];
                i++;
            }
        }

        return boardAs2DArray;
    }
}


