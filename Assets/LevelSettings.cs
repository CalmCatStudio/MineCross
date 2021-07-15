using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    [SerializeField]
    private int numberOfBombs = default;
    public int NumberOfBombs 
    { 
        get 
        {
            return numberOfBombs; 
        } 
    }
}
