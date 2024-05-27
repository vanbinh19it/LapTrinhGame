using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    string lvname;
    public void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }
    
    public void SceneMenuLv()
    {
        SceneManager.LoadScene("MenuLv");
    }
    public void StartLv()
    {
        string a=SelectLv.GetLvName();
        SceneManager.LoadScene(a);
        //SampleScene
    }
}
