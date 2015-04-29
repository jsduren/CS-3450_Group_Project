using UnityEngine;
using System.Collections;

public class AimController : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponentInParent<UnitController>() && GetComponentInParent<UnitController>().ThisUnit._CurTarget && GetComponentInParent<UnitController>().ThisUnit._UnitGameObject.GetComponentInChildren<TurretRotation>() && GetComponentInParent<UnitController>().ThisUnit._UnitGameObject.GetComponentInChildren<GunRotation>() && GetComponentInParent<UnitController>().ThisUnit._UnitGameObject.GetComponentInChildren<AimTilt>() && GetComponentInParent<UnitController>().ThisUnit._UnitGameObject.GetComponentInChildren<AimPan>())
        {
            Vector3 targetPosition2d = new Vector3(GetComponentInParent<UnitController>().ThisUnit._CurTarget.transform.position.x, GetComponentInParent<UnitController>().ThisUnit._CurTarget.transform.position.y + 1, GetComponentInParent<UnitController>().ThisUnit._CurTarget.transform.position.z);
            Transform aim_pan = GetComponentInParent<UnitController>().ThisUnit._UnitGameObject.GetComponentInChildren<AimPan>().transform;
            aim_pan.LookAt(targetPosition2d);
            aim_pan.eulerAngles = new Vector3(0, aim_pan.eulerAngles.y, 0);
            //if (GetComponentInParent<UnitController>().ThisUnit._UnitType == UType.Jeep)
            //{

                Transform aim_tilt = GetComponentInParent<UnitController>().ThisUnit._UnitGameObject.GetComponentInChildren<AimTilt>().transform;
                aim_tilt.LookAt(targetPosition2d);
                //aim_tilt.eulerAngles = new Vector3(aim_tilt.eulerAngles.x, 0, 0);

                GetComponentInParent<UnitController>().ThisUnit._UnitGameObject.GetComponentInChildren<TurretRotation>().transform.rotation = Quaternion.RotateTowards(GetComponentInParent<UnitController>().ThisUnit._UnitGameObject.GetComponentInChildren<TurretRotation>().transform.rotation, aim_pan.rotation, Time.deltaTime * BaseStaticValues.Unit.RotationDamping);

                //_UnitGameObject.GetComponentInChildren<GunRotation>().transform.LookAt(targetPosition2d);
                GetComponentInParent<UnitController>().ThisUnit._UnitGameObject.GetComponentInChildren<GunRotation>().transform.rotation = Quaternion.RotateTowards(GetComponentInParent<UnitController>().ThisUnit._UnitGameObject.GetComponentInChildren<GunRotation>().transform.rotation, aim_tilt.rotation, Time.deltaTime * BaseStaticValues.Unit.RotationDamping);
            //}
            //else
            //{

                //Transform aim_tilt = _UnitGameObject.GetComponentInChildren<AimTilt>().transform;
                //aim_tilt.LookAt(targetPosition2d);
                //aim_tilt.eulerAngles = new Vector3(aim_tilt.eulerAngles.x, 0, 0);
                //_UnitGameObject.GetComponentInChildren<TurretRotation>().transform.LookAt(targetPosition2d);
                //GetComponentInParent<UnitController>().ThisUnit._UnitGameObject.GetComponentInChildren<TurretRotation>().transform.rotation = Quaternion.RotateTowards(GetComponentInParent<UnitController>().ThisUnit._UnitGameObject.GetComponentInChildren<TurretRotation>().transform.rotation, aim_pan.rotation, Time.deltaTime * BaseStaticValues.Unit.RotationDamping * 2);
            //}
        }
	}
}
