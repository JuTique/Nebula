using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

public class AbrirInstrucciones : MonoBehaviour
{
    public void IrInstrucciones()
    {
        MMSceneLoadingManager.LoadScene("Instrucciones");
    }
}
