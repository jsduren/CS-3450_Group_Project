using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Texture backgroundTexture;
	// Use this for initialization
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);
        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        GUIStyle titleStyle = new GUIStyle(GUI.skin.label);
        buttonStyle.fontSize = 30;
        titleStyle.fontSize = 70;

        var top = (Screen.height/2)-125;
        var left = (Screen.width/2)+125;

        GUI.Label(new Rect(left-400, top-175, 500, 200), "MECH ARMIES",titleStyle);

        if (GUI.Button(new Rect(left,top,200,100), "Start Game",buttonStyle))
        {
            Application.LoadLevel(1);
        }

        top += 150;
        if (GUI.Button(new Rect(left, top, 200, 100), "Exit", buttonStyle))
        {
            Application.Quit();
        }
    }
}
