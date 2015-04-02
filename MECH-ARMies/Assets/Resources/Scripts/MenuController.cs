using System;
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class MenuController : MonoBehaviour
{
    public Rect guiWindow;
    private float windowWidth = Screen.width * 0.6f;
    private float windowHeight = Screen.height * 0.6f;
    public bool IsVisible = false;

    private GameObject jet;
    private JetController jetController;

    private int unitIndex = 0;
    private int orderIndex = 0;
    public Texture infantryPortrait;
    public Texture vehiclePortrait;
    public Texture turretPortarit;
    public Texture moveButton;
    public Texture guardButton;
    private Texture[] units;
    private Texture[] orders;
    private int[] unitCosts;
    private int[] orderCosts;
    private string[] unitText;
    private string[] orderText;

    private int currentIndex = 0;
    private Color defaultColor;
    private Color disableColor;
    private int _keyCooldown = 0;

    private void Start()
    {
        defaultColor = GUI.color;
        disableColor = new Color(255, 255, 255, 0.5f);
        _keyCooldown = 0;

        units = new[]
        {
            (Texture) Resources.Load("Textures/Infantry"),
            (Texture) Resources.Load("Textures/Jeep"),
            (Texture) Resources.Load("Textures/Turret")
        };

        orders = new[]
        {
            
            (Texture) Resources.Load("Textures/AttackMainButton"),
            (Texture) Resources.Load("Textures/GuardButton"),
            (Texture) Resources.Load("Textures/StandGroundButton"),
            (Texture) Resources.Load("Textures/AdvanceButton")
            //(Texture) Resources.Load("Textures/ResupplyButton"),
            //(Texture) Resources.Load("Textures/CircleButton")
        };

        orderText = new[]
        {
            "Attack Main", "Guard", "Stand Ground", "Nearest Base"
        };

        unitCosts = new[]
        {
            100, 250, 250
        };

        orderCosts = new[]
        {
            50, 75, 25, 0, 25, 50 
        };

        unitText = new[]
        {
            "Infantry", "Humvee", "Turret"
        };


    }

    private void OnGUI()
    {
        if (!IsVisible) return;
        var windowRect = new Rect((Screen.width / 2) - (windowWidth / 2),
            (Screen.height / 2) - (windowHeight / 2), Math.Max(windowWidth, 200), Math.Max(windowHeight, 400));
        guiWindow = GUI.Window(0, windowRect, drawWindow, "Command Menu");
    }

    private void drawWindow(int windowID)
    {
        const int arrowButtonWidth = 30;
        const int arrowButtonHeight = 60;
        const int arrowButtonTopPadding = 20;
        const int unitPortraitWidth = arrowButtonHeight + arrowButtonTopPadding * 2;
        const int unitPortraitHeight = unitPortraitWidth;
        const int spacing = 5;
        const int costLineHeight = 20;

        ////Unit type select
        SetSelected(0);
        var unitLeftArrowButtonX = windowWidth * 0.5f - unitPortraitWidth * 0.5f - spacing - arrowButtonWidth;
        var unitLeftArrowButtonY = windowHeight * 0.1f;
        if (GUI.Button(new Rect(
            unitLeftArrowButtonX,
            unitLeftArrowButtonY + arrowButtonTopPadding,
            arrowButtonWidth,
            arrowButtonHeight), "<"))
            UnitLeftButton();

        var unitRightArrowButtonX = unitLeftArrowButtonX + arrowButtonWidth + unitPortraitWidth + spacing * 2;
        var unitRightArrowButtonY = unitLeftArrowButtonY;
        if (GUI.Button(new Rect(
            unitRightArrowButtonX,
            unitRightArrowButtonY + arrowButtonTopPadding,
            arrowButtonWidth,
            arrowButtonHeight), ">"))
            UnitRightButton();

        //put unit portrait texture in here
        var unitPortraitSkinX = unitLeftArrowButtonX + arrowButtonWidth + spacing;
        var unitPortraitSkinY = unitLeftArrowButtonY;
        var unitPortraitRect = new Rect(unitPortraitSkinX, unitPortraitSkinY, unitPortraitWidth, unitPortraitHeight);
        GUI.DrawTexture(unitPortraitRect, units[unitIndex]);

        //put unit cost text here
        GUI.Label(new Rect(unitPortraitSkinX, unitPortraitSkinY + unitPortraitHeight + spacing, 200, 30),
            unitText[unitIndex] + " - " + unitCosts[unitIndex] + " Credits");

        ////Order select
        SetSelected(1);

        var orderLeftArrowButtonX = windowWidth * 0.5f - unitPortraitWidth * 0.5f - spacing - arrowButtonWidth;
        var orderLeftArrowButtonY = unitLeftArrowButtonY + unitPortraitHeight + spacing + costLineHeight + spacing;
        if (GUI.Button(new Rect(
            orderLeftArrowButtonX,
            orderLeftArrowButtonY + arrowButtonTopPadding,
            arrowButtonWidth,
            arrowButtonHeight), "<"))
            OrderLeftButton();

        var orderRightArrowButtonX = orderLeftArrowButtonX + arrowButtonWidth + unitPortraitWidth + spacing * 2;
        var orderRightArrowButtonY = orderLeftArrowButtonY;
        if (GUI.Button(new Rect(
            orderRightArrowButtonX,
            orderRightArrowButtonY + arrowButtonTopPadding,
            arrowButtonWidth,
            arrowButtonHeight), ">"))
            OrderRightButton();

        //put order portrait texture in here
        var orderPortraitSkinX = orderLeftArrowButtonX + arrowButtonWidth + spacing;
        var orderPortraitSkinY = orderLeftArrowButtonY;
        var orderPortraitRect = new Rect(orderPortraitSkinX, orderPortraitSkinY, unitPortraitWidth, unitPortraitHeight);
        GUI.DrawTexture(orderPortraitRect, orders[orderIndex]);

        //put order cost text here
        GUI.Label(new Rect(orderPortraitSkinX, orderPortraitSkinY + unitPortraitHeight + spacing, 200, 30),
            orderText[orderIndex] + " - " + orderCosts[orderIndex] + " Credits");

        //Unit build button
        SetSelected(2);
        var buildButtonRect = new Rect(orderPortraitSkinX,
            orderPortraitSkinY + (unitPortraitHeight * 1.25f) + costLineHeight + spacing, unitPortraitWidth,
            unitPortraitHeight * 0.5f);

        if (GUI.Button(buildButtonRect, "Construct Unit"))
            ConstructButton();

        //Exit button
    }

    private void UnitLeftButton()
    {
        unitIndex = Math.Max(0, unitIndex - 1);
        _keyCooldown = 3;
    }
    private void UnitRightButton()
    {
        unitIndex = Math.Min(units.Length - 1, unitIndex + 1);
        _keyCooldown = 3;
    }
    private void OrderLeftButton()
    {
        orderIndex = Math.Max(0, orderIndex - 1);
        _keyCooldown = 3;
    }
    private void OrderRightButton()
    {
        orderIndex = Math.Min(orders.Length - 1, orderIndex + 1);
        _keyCooldown = 3;
    }
    private void ConstructButton()
    {
        ConstructUnit(unitText[unitIndex], orderText[orderIndex]);        
    }

    private void SetSelected(int index)
    {
        if (currentIndex == index)
        {
            GUI.enabled = true;
            GUI.color = defaultColor;
        }
        else
        {
            GUI.enabled = false;
            GUI.color = disableColor;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            IsVisible = !IsVisible;
            if (IsVisible)
                currentIndex = 0;
        }

        if (IsVisible)
        {
            if (_keyCooldown > 0) _keyCooldown--;
            else
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    currentIndex = Math.Max(currentIndex - 1, 0);
                    _keyCooldown = 3;
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    currentIndex = Math.Min(currentIndex + 1, 2);
                    _keyCooldown = 3;
                }
                else switch (currentIndex)
                    {
                        case 0:
                            {
                                if (Input.GetAxis("Horizontal") < 0)
                                    UnitLeftButton();
                                if (Input.GetAxis("Horizontal") > 0)
                                    UnitRightButton();
                            }
                            break;
                        case 1:
                            {
                                if (Input.GetAxis("Horizontal") < 0)
                                    OrderLeftButton();
                                if (Input.GetAxis("Horizontal") > 0)
                                    OrderRightButton();
                            }
                            break;
                        case 2:
                            {
                                if (Input.GetButton("Fire1"))
                                    ConstructButton();
                            }
                            break;
                    }
            }
        }
    }

    private void ConstructUnit(string unit, string program)
    {
        jet = GameObject.FindWithTag("Player");
        jet.GetComponent<UnitController>().ThisUnit.createCargo(unit, program);
        IsVisible = false;
    }

}
