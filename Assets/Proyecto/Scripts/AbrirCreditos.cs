using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

public class AbrirCreditos : MonoBehaviour
{
    public void Ircreditos()
    {
        MMSceneLoadingManager.LoadScene("Creditos");
    }
}
