using UnityEngine;
using UnityEngine.SceneManagement;

public class AbrirLogros : MonoBehaviour
{
    public void IrLogros()
    {
        SceneManager.LoadScene("Logros");
    }

    public void IrNivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void IrHome()
    {
        SceneManager.LoadScene("Home");
    }
}
