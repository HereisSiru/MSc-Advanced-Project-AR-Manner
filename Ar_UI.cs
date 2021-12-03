using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using static FairyGUI.UIContentScaler;

public class Ar_UI : MonoBehaviour
{
    GComponent Main;


    public SpriteRenderer[] sprites;

    void Start()
    {
        Main = GetComponent<UIPanel>().ui;

        Main.GetChild("返回").asButton.onClick.Add(() =>
        {
            //切换到场景0
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        });
    }

    bool _Lock = false; //用于限制 重复
    void Update()
    {
        if (sprites[0].enabled==false && sprites[1].enabled==false)
        {
            Main.GetChild("n6").visible = true;        //当扫描成功后  将识别框显示出来

            Main.GetChild("识别按钮").asCom.GetChild("icon").asLoader.url = "";   //去除按钮的图片状态

            Main.GetChild("识别按钮").asButton.onClick.Clear();  // 清理按钮按下的效果

            _Lock = false;

            Main.GetChild("识别按钮").visible = false;
        }
        else
        {
            Main.GetChild("n6").visible = false;   //当扫描成功后  将识别框隐藏

            if (_Lock)
            {
                return;
            }

            Main.GetChild("识别按钮").visible = true;

            if (sprites[0].enabled)
            {
                Main.GetChild("识别按钮").asCom.GetChild("icon").asLoader.url = "ui://opxl2vx0tkrrk";  //设置对应的图片

                // 给按钮添加一个 更换图片的方法
                Main.GetChild("识别按钮").asButton.onClick.Add(() =>  
                {
                    Main.GetChild("识别按钮").asCom.GetChild("icon").asLoader.url = "ui://opxl2vx0tkrr5";
                });

                _Lock = true;
            }

            if (sprites[1].enabled)
            {
                Main.GetChild("识别按钮").asCom.GetChild("icon").asLoader.url = "ui://opxl2vx0tkrrj";

                Main.GetChild("识别按钮").asButton.onClick.Add(() =>
                {
                    Main.GetChild("识别按钮").asCom.GetChild("icon").asLoader.url = "ui://opxl2vx0tkrr4";
                });

                _Lock = true;
            }
        }
    }
}
