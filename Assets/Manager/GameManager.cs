using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Player player;
    [SerializeField] private EndPole endPole;
    [SerializeField] private GameObject playerSpawnPoint;

    public int score = 0;
    public float timer = 0.0f;
    public bool isGameRunning = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        player.OnPlayerDied += Player_OnPlayerDied;
        endPole.OnEndPoleReached += EndPole_OnEndPoleReached;
        isGameRunning = true;
    }

    private void Update()
    {
        if(isGameRunning) timer += Time.deltaTime;
    }

    private void Player_OnPlayerDied(object sender, EventArgs e)
    {
        Debug.Log("Player died");
        player.transform.position = playerSpawnPoint.transform.position;
    }

    private void EndPole_OnEndPoleReached(object sender, EventArgs e)
    {
        Debug.Log("Player win");
        score = 100 - (int)timer;
        isGameRunning = false;
    }
}
