using System;
using UnityEngine;

public class GameOverMenuController : MonoBehaviour
{
    public Rect guiWindow;
    float windowWidth = Screen.width * 0.6f;
    float windowHeight = Screen.height * 0.6f;
    public bool IsVisible = false;

    void Start()
    {

    }

    void OnGUI()
    {
        if (!IsVisible) return;
        Rect windowRect = new Rect((Screen.width / 2) - (windowWidth / 2),
            (Screen.height / 2) - (windowHeight / 2), Math.Max(windowWidth, 200), Math.Max(windowHeight, 400));
        guiWindow = GUI.Window(0, windowRect, drawWindow, "");
    }

    private void drawWindow(int windowID)
    {
        GUI.Label(new Rect(20, 20, 200,50),"GAME OVER!!!");
    }

    public void ShowMenu()
    {
        IsVisible = true;
    }
}
