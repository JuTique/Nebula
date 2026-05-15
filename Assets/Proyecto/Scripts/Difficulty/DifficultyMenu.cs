using UnityEngine;
using UnityEngine.SceneManagement;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DifficultyMenu : MonoBehaviour
{
    [SerializeField] private GameObject difficultyMenuPanel;
    [SerializeField] private Button[] difficultyButtons;

    public void SelectDifficulty(int difficulty)
    {
        DifficultyManager.SetDifficulty((DifficultyManager.Difficulty)difficulty);
        Debug.Log("Dificultad cambiada: " + difficulty);

        // Mantener el panel visible y marcar el botón seleccionado.
        if (difficultyButtons != null && difficulty >= 0 && difficulty < difficultyButtons.Length)
        {
            // Reactivar todos los botones primero
            for (int i = 0; i < difficultyButtons.Length; i++)
            {
                if (difficultyButtons[i] != null)
                {
                    difficultyButtons[i].interactable = true;
                }
            }

            // "Dejar presionado" el botón seleccionado desactivando su interactable
            var btn = difficultyButtons[difficulty];
            if (btn != null)
            {
                btn.interactable = false;
                // también lo seleccionamos en el EventSystem para foco visual
                if (EventSystem.current != null)
                {
                    EventSystem.current.SetSelectedGameObject(btn.gameObject);
                }
            }
        }
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
