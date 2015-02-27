using System;
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class MenuController : MonoBehaviour
{
    public Rect guiWindow;
    float windowWidth = Screen.width * 0.6f;
    float windowHeight = Screen.height * 0.6f;
    public bool IsVisible = false;

    private int unitIndex = 0;
    private int orderIndex = 0;
    public Texture infantryPortrait;
    public Texture vehiclePortrait;
    public Texture moveButton;
    public Texture guardButton;
    private Texture[] portraits;
    private Texture[] orders;
    private int[] unitCosts;
    private int[] orderCosts;
    private string[] unitText;
    private string[] orderText;

    void Start()
    {
        portraits = new Texture[]
        {
            infantryPortrait,
            vehiclePortrait
        };

        orders = new Texture[]
        {
            moveButton,
            guardButton
        };

        unitCosts = new int[]
        {
            100,250
        };

        orderCosts = new int[]
        {
            50,0
        };

        unitText = new string[]
        {
            "Infantry", "Humvee"
        };

        orderText = new string[]
        {
            "Advance", "Guard"
        };
    }

    void OnGUI()
    {
        if (!IsVisible) return;
        Rect windowRect = new Rect((Screen.width / 2) - (windowWidth / 2),
            (Screen.height / 2) - (windowHeight / 2), Math.Max(windowWidth, 200), Math.Max(windowHeight, 400));
        guiWindow = GUI.Window(0, windowRect, drawWindow, "Command Menu");
    }

    private void drawWindow(int windowID)
    {
        const int arrowButtonWidth = 30;
        const int arrowButtonHeight = 60;
        const int arrowButtonTopPadding = 20;
        const int unitPortraitWidth = arrowButtonHeight + arrowButtonTopPadding*2;
        const int unitPortraitHeight = unitPortraitWidth;
        const int spacing = 5;
        const int costLineHeight = 20;

        ////Unit type select

        var unitLeftArrowButtonX = windowWidth*0.5f - unitPortraitWidth*0.5f - spacing - arrowButtonWidth;
        var unitLeftArrowButtonY = windowHeight*0.1f;
        if (GUI.Button(new Rect(
            unitLeftArrowButtonX,
            unitLeftArrowButtonY + arrowButtonTopPadding,
            arrowButtonWidth,
            arrowButtonHeight), "<"))
            unitIndex = Math.Max(0, unitIndex - 1);

        var unitRightArrowButtonX = unitLeftArrowButtonX + arrowButtonWidth + unitPortraitWidth + spacing * 2;
        var unitRightArrowButtonY = unitLeftArrowButtonY;
        if (GUI.Button(new Rect(
            unitRightArrowButtonX,
            unitRightArrowButtonY + arrowButtonTopPadding,
            arrowButtonWidth,
            arrowButtonHeight), ">"))
            unitIndex = Math.Min(1, unitIndex + 1);

        //put unit portrait texture in here
        var unitPortraitSkinX = unitLeftArrowButtonX + arrowButtonWidth + spacing;
        var unitPortraitSkinY = unitLeftArrowButtonY;
        var unitPortraitRect = new Rect(unitPortraitSkinX, unitPortraitSkinY, unitPortraitWidth, unitPortraitHeight);
        GUI.DrawTexture(unitPortraitRect, portraits[unitIndex]);

        //put unit cost text here
        GUI.Label(new Rect(unitPortraitSkinX, unitPortraitSkinY + unitPortraitHeight + spacing, 200, 30), unitText[unitIndex] + " - " + unitCosts[unitIndex] + " Credits");

        ////Order select

        var orderLeftArrowButtonX = windowWidth * 0.5f - unitPortraitWidth * 0.5f - spacing - arrowButtonWidth;
        var orderLeftArrowButtonY = unitLeftArrowButtonY + unitPortraitHeight + spacing + costLineHeight + spacing;
        if (GUI.Button(new Rect(
            orderLeftArrowButtonX,
            orderLeftArrowButtonY + arrowButtonTopPadding,
            arrowButtonWidth,
            arrowButtonHeight), "<"))
            orderIndex = Math.Max(0, orderIndex - 1);

        var orderRightArrowButtonX = orderLeftArrowButtonX + arrowButtonWidth + unitPortraitWidth + spacing * 2;
        var orderRightArrowButtonY = orderLeftArrowButtonY;
        if (GUI.Button(new Rect(
            orderRightArrowButtonX,
            orderRightArrowButtonY + arrowButtonTopPadding,
            arrowButtonWidth,
            arrowButtonHeight), ">"))
        {
            orderIndex = Math.Min(1, orderIndex + 1);
            print("You clicked the button!");
        }

        //put order portrait texture in here
        var orderPortraitSkinX = orderLeftArrowButtonX + arrowButtonWidth + spacing;
        var orderPortraitSkinY = orderLeftArrowButtonY;
        var orderPortraitRect = new Rect(orderPortraitSkinX, orderPortraitSkinY, unitPortraitWidth, unitPortraitHeight);
        GUI.DrawTexture(orderPortraitRect, orders[orderIndex]);

        //put order cost text here
        GUI.Label(new Rect(orderPortraitSkinX, orderPortraitSkinY + unitPortraitHeight + spacing, 200, 30), orderText[orderIndex] + " - " + orderCosts[orderIndex] + " Credits");

        //Unit build button
        var buildButtonRect = new Rect(orderPortraitSkinX, orderPortraitSkinY+(unitPortraitHeight*1.25f)+costLineHeight+spacing, unitPortraitWidth, unitPortraitHeight*0.5f);
        
        if (GUI.Button(buildButtonRect, "Construct Unit"))
        {
            ConstructUnit();
        }

        //Exit button
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            IsVisible = !IsVisible;
        }
    }

    void ConstructUnit()
    {
        
    }
}
