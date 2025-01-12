using System.Reflection;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Intro,
    Playing,
    Dead,
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState state = GameState.Intro;

    public int Lives = 3;

    [Header("References")]
    public GameObject introUI;
    public GameObject enemySpawner;
    public GameObject foodSpawner;
    public GameObject goldenSpawner;
    public Player player;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        introUI.SetActive(true);
    }

    void Update()
    {
        if(state == GameState.Intro && Input.GetKeyDown(KeyCode.Space))
        {
            state = GameState.Playing;
            introUI.SetActive(false);
            enemySpawner.SetActive(true);
            foodSpawner.SetActive(true);
            goldenSpawner.SetActive(true);
        }

        if(state == GameState.Playing && Lives == 0)
        {
            player.KillPlayer();
            enemySpawner.SetActive(false);
            foodSpawner.SetActive(false);
            goldenSpawner.SetActive(false);
            state = GameState.Dead;
        }
        if(state == GameState.Dead && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("main");
        }
    }
}
