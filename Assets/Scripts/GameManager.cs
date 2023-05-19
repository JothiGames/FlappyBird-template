using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Spawner spawner;
    private PlayfabManager playfabManager;
    private Admob adMob;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreBoardText;
    public GameObject playButton;
    public GameObject leaderboardButton;
    public GameObject logo;
    public GameObject scoreUi;
    public GameObject scoreBoard;
    public GameObject leaderBoard;
    private TMP_Text scoreUItext;
    public int score { get; private set; }

    
    private void Awake()
    {
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        playfabManager = FindObjectOfType<PlayfabManager>();
        adMob = FindObjectOfType<Admob>();

        Pause();
    }

    public void Start()
    {
        scoreUItext = scoreUi.GetComponent<TMP_Text>();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        
        scoreUi.SetActive(true);
        playButton.SetActive(false);
        logo.SetActive(false);
        leaderboardButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Continue()
    {
        score = 0;
        scoreText.text = score.ToString();

        scoreUi.SetActive(true);
        scoreBoard.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        Pause();
        scoreBoardText.text = score.ToString();
        scoreBoard.SetActive(true);
        scoreUi.SetActive(false);
        playfabManager.SendLeaderboard(score);
        adMob.AdCall();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void QuitApplication()
    {
        Application.Quit();
        Debug.Log("function is called");
    }

    public void LeaderBoardEnable()
    {
        leaderBoard.SetActive(true);
    }

    public void LeaderBoardDisable()
    {
        leaderBoard.SetActive(false);
    }

    public void Retry()
    {
        //adMob.AdCall();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
