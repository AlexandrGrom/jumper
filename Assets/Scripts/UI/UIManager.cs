using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static bool isPause;
    public void SetTimescale()
    {
        Time.timeScale = isPause ? 1 : 0;
        isPause = !isPause;
    }

    
}
