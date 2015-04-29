using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CargoUI : MonoBehaviour {

    Texture[] units;
    Texture[] orders;
    bool init = false;
    private PlayerPlane _plane;
    private PlayerPlane Plane
    {
        get
        {
            if (_plane != null) return _plane;
            var jet = GameObject.FindWithTag("Player");
            _plane = (PlayerPlane)jet.GetComponent<UnitController>().ThisUnit;
            return _plane;
        }
    }

    public void Start()
    {
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
        };
        init = true;

        
    }
    public void OnGUI()
    {
        if (!init) return;

        var top = 100;
        var left = 0;
        var index = 0;

        foreach (var g in Plane._cargo)
        {
            var obj = ""+g._GameObject;
            if (obj == null || !obj.Any()) continue;

            var unitRect = new Rect(left, top+(40*index), 40, 40);
            index++;

            switch (obj)
            {
                case ("Infantry (UnityEngine.GameObject)"):
                    {
                        GUI.DrawTexture(unitRect, units[0]);
                    }
                    break;
                case ("Jeep (UnityEngine.GameObject)"):
                    {
                        GUI.DrawTexture(unitRect, units[1]);
                    }
                    break;
            }
        }
    }
}
