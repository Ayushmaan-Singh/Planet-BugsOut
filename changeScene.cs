using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void onchange()
    {
        SceneManager.LoadScene(4);
    }
}
