using UnityEngine;

public class PickUpScoreManager : MonoBehaviour
{
    public static PickUpScoreManager Instance;
    private int currentScore = 0;
    private int totalPickups = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        totalPickups = GameObject.FindGameObjectsWithTag("PickUp").Length;
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Current Score: " + currentScore + "/" + totalPickups);
    }

    public bool HasMaxScore()
    {
        return currentScore >= totalPickups;
    }
}
