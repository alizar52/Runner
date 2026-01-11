using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI; // Ссылка на Canvas меню

    private void Start()
    {
        // Остановить время при запуске игры
        Time.timeScale = 0;
        mainMenuUI.SetActive(true); // Показать меню
    }

    public void StartGame()
    {
        // Скрыть меню и запустить игру
        mainMenuUI.SetActive(false);
        Time.timeScale = 1; // Возобновить время
    }

    public void QuitGame()
    {
        Application.Quit(); // Выйти из игры
    }
}