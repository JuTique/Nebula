using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

public class VolverHome : MonoBehaviour
{
    public void IrHome()
    {
        MMSceneLoadingManager.LoadScene("Home");
    }
}
