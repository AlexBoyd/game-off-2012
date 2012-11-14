using UnityEngine;
using System.Collections;

public class UICameraSingleton : SingletonComponent<UICameraSingleton>
{
    public Camera MainUICam = null;
}
