using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText; // ����� ��� ����������� ����� �� ����� ����
    public TextMeshProUGUI gameOverScoreText; // ����� ��� ����������� ����� � UI "Game Over"
    public GameObject gameOverUI; // ������ �� Canvas "Game Over"

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score; // ��������� ����� �� ����� ����
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true); // �������� ����� "Game Over"
        gameOverScoreText.text = "Final Score: " + score; // ���������� ��������� ����
        Time.timeScale = 0; // ���������� �����
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // ����������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ������������� ������� �����

        // ����� ��������� ������
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        player.isGameOver = false;
        player.rb.linearVelocity = Vector3.zero; // �������� �������� ������
    }

    public void QuitGame()
    {
        Application.Quit(); // ����� �� ����
    }
}
