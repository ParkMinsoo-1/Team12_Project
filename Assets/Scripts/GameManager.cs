using System.Collections;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState
{
    InLobby,
    InMap,
    InBase,
    InStage
}

public class GameManager: MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �����ϰ� �ʹٸ� ���
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
        }
        isGameRunning = true;
    }

    public GameState currentState;
    public GameState nextState;
    bool isStateRunning = false;
    bool isGameRunning = false;

    private void Start()
    {
        isStateRunning = true;
        nextState = GameState.InLobby;
        StartCoroutine(UpdateState());
    }

    private void Update()
    {
        if (Input.GetKeyDown("3"))
        {
            SceneManager.LoadScene("LobbyScene");
        }

    }
    private IEnumerator UpdateState()
    {
        while (isGameRunning)
        {
            currentState = nextState;
            switch (currentState)
            {
                case GameState.InLobby:
                    yield return !isStateRunning;
                    nextState = DecideNextState();
                    break;

                case GameState.InMap:
                    yield return !isStateRunning;
                    nextState = DecideNextState();
                    break;

                case GameState.InBase:
                    yield return !isStateRunning;
                    nextState = DecideNextState();
                    break;

                case GameState.InStage:
                    yield return !isStateRunning;
                    nextState = DecideNextState();
                    break;
            }
        }
    }
    private GameState DecideNextState()
    {


        return GameState.InLobby;
    }

    public void EndLobby()
    {
        SceneManager.LoadScene("ForestAndCamp");
    }
}
