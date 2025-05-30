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
    public string select;
    public GameState currentState;
    public GameState nextState;
    public bool isStateRunning = false;
    bool isGameRunning = false;

    public Camera cam;


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
                    yield return new WaitUntil(() => !isStateRunning);
                    nextState = DecideNextState();
                    ToNextScene();
                    break;

                case GameState.InMap:
                    yield return new WaitUntil(() => !isStateRunning);
                    nextState = DecideNextState();
                    ToNextScene();
                    break;

                case GameState.InBase:
                    yield return new WaitUntil(() => !isStateRunning);
                    nextState = DecideNextState();
                    ToNextScene();
                    break;

                case GameState.InStage:
                    yield return new WaitUntil(() => !isStateRunning);
                    nextState = DecideNextState();
                    ToNextScene();
                    break;
            }
        }
    }
    private GameState DecideNextState()
    {
        isStateRunning = true;

        if (currentState == GameState.InLobby)
        {
            return GameState.InBase;
        }

        if (currentState == GameState.InBase || currentState == GameState.InStage)
        {
            return GameState.InMap;
        }

        if (currentState == GameState.InMap)
        {
            switch (select)
            {
                case "Base":
                    return GameState.InBase;

                case "Stage":
                    return GameState.InStage;
            }
        }
        return GameState.InLobby;
    }
    public void ToNextScene()
    {
        StartCoroutine(ToNextSceneC());
        
    }
    public IEnumerator ToNextSceneC()
    {
        switch (nextState)
        {
            case GameState.InBase:
                yield return SceneManager.LoadSceneAsync("ForestAndCamp"); //베이스 씬으로 이름 변경 필요
                break;

            case GameState.InStage:
                yield return SceneManager.LoadSceneAsync("StageScene"); //스테이지 씬으로 이름 변경 필요
                break;

            case GameState.InMap:
                yield return SceneManager.LoadSceneAsync("MapScene"); 
                break;

        }
        NextSceneSetting();
        yield break;
    }
    public void NextSceneSetting()
    {
        GameObject spawnPoint = GameObject.FindWithTag("SpawnPoint");
        PlayerManager.Instance.Player.transform.position = spawnPoint.transform.position;
        if (nextState == GameState.InMap)
        {
            PlayerManager.Instance.Player.gameObject.SetActive(false);
            FollowCamera playerCam = cam.GetComponent<FollowCamera>();
            playerCam.transform.rotation = Quaternion.Euler(90, 0, 0);
            playerCam.target = GameObject.FindWithTag("Map").transform;
            cam.orthographicSize = 8f;
            playerCam.offset = new Vector3(0, 2f, 0);
        }
    }
    //public void EndLobby()
    //{
    //    SceneManager.LoadScene("ForestAndCamp");
    //}
    public void StateEnd()
    {
        isStateRunning = false;
        InfoUi infoUi = UiManager.Instance.mainUi.infoLayout.GetComponent<InfoUi>();
        infoUi.OnShowScenePanel();
    }
}
