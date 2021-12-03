using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using static FairyGUI.UIContentScaler;

public class HomeUI : MonoBehaviour
{
    GComponent Main;

    //使用协程的方式 来达到 间隔3秒后 切换到场景1
    void Start()
    {
        Main = GetComponent<UIPanel>().ui;

        Main.GetChild("切换场景").asButton.onClick.Add(() =>
        {
            //切换到场景1
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        });
    }
}
