using UnityEngine;
using System.Collections;

public class AimController : MonoBehaviour {

    private UnitController unitCont;

	// Use this for initialization
	void Start () {
        unitCont = gameObject.GetComponentInParent<UnitController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (unitCont.ThisUnit._CurTarget != null)
        {
            Vector3 targetPosition2d = new Vector3(unitCont.ThisUnit._CurTarget.transform.position.x, unitCont.ThisUnit._CurTarget.transform.position.y + 1, unitCont.ThisUnit._CurTarget.transform.position.z);
            Transform aim_pan = unitCont.ThisUnit._UnitGameObject.GetComponentInChildren<AimPan>().transform;
            aim_pan.LookAt(targetPosition2d);
            aim_pan.eulerAngles = new Vector3(0, aim_pan.eulerAngles.y, 0);
            if (unitCont.ThisUnit._UnitType == UType.Jeep)
            {

                Transform aim_tilt = unitCont.ThisUnit._UnitGameObject.GetComponentInChildren<AimTilt>().transform;
                aim_tilt.LookAt(targetPosition2d);
                //aim_tilt.eulerAngles = new Vector3(aim_tilt.eulerAngles.x, 0, 0);

                unitCont.ThisUnit._UnitGameObject.GetComponentInChildren<TurretRotation>().transform.rotation = Quaternion.RotateTowards(unitCont.ThisUnit._UnitGameObject.GetComponentInChildren<TurretRotation>().transform.rotation, aim_pan.rotation, Time.deltaTime * BaseStaticValues.Unit.RotationDamping);

                //_UnitGameObject.GetComponentInChildren<GunRotation>().transform.LookAt(targetPosition2d);
                unitCont.ThisUnit._UnitGameObject.GetComponentInChildren<GunRotation>().transform.rotation = Quaternion.RotateTowards(unitCont.ThisUnit._UnitGameObject.GetComponentInChildren<GunRotation>().transform.rotation, aim_tilt.rotation, Time.deltaTime * BaseStaticValues.Unit.RotationDamping);
            }
            else
            {

                //Transform aim_tilt = _UnitGameObject.GetComponentInChildren<AimTilt>().transform;
                //aim_tilt.LookAt(targetPosition2d);
                //aim_tilt.eulerAngles = new Vector3(aim_tilt.eulerAngles.x, 0, 0);
                //_UnitGameObject.GetComponentInChildren<TurretRotation>().transform.LookAt(targetPosition2d);
                unitCont.ThisUnit._UnitGameObject.GetComponentInChildren<TurretRotation>().transform.rotation = Quaternion.RotateTowards(unitCont.ThisUnit._UnitGameObject.GetComponentInChildren<TurretRotation>().transform.rotation, aim_pan.rotation, Time.deltaTime * BaseStaticValues.Unit.RotationDamping * 2);
            }
        }
	}
}
