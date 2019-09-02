using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitShooting : MonoBehaviour {

	public Unit unit;
	bool selected;
	Weapon weapon;

	void Start() {
		unit = GetComponent<Unit>();
		if(!unit) {
			Debug.LogError("UnitShooting script attached to gameObject without unit");
			return;
		}

		unit.OnSelect.AddListener(OnSelect);
		unit.OnDeselect.AddListener(OnDeselect);

		weapon = unit.weapons[0];
	}

	void OnSelect() {
		selected = true;
	}

	void OnDeselect() {
		RaycastHit hit;
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f, LayerMask.GetMask("Unit"))) {
			Unit target = hit.transform.GetComponent<Unit>();
			Shoot(target);
		}
		selected = false;
	}

	void Shoot(Unit target) {
		Debug.LogFormat("Shooting {0} with {1}", target.name, weapon.name);
	}

	void OnDestroy() {
		if(unit) {
			unit.OnSelect.RemoveListener(OnSelect);
			unit.OnDeselect.RemoveListener(OnDeselect);
		}
	}
}
