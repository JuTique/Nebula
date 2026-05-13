using UnityEngine;
using UnityEngine.SceneManagement;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

public class DifficultyMenu : MonoBehaviour
{
    [SerializeField] private GameObject difficultyMenuPanel;

    public void SelectDifficulty(int difficulty)
    {
        DifficultyManager.SetDifficulty((DifficultyManager.Difficulty)difficulty);
        
        Debug.Log("Dificultad cambiada. Ocultando menú...");
        HideDifficultyMenu();
    }

    public void ShowDifficultyMenu()
    {
        if (difficultyMenuPanel != null)
        {
            difficultyMenuPanel.SetActive(true);
        }
    }

    public void HideDifficultyMenu()
    {
        if (difficultyMenuPanel != null)
        {
            difficultyMenuPanel.SetActive(false);
        }
    }
}
