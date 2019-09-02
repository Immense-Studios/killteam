using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour {

	Unit unit;
	public int MoveSpeed = 6;
	private Dice d6 = new D6();
	private Dice d3 = new D3();

	[SerializeField] bool selected;

	void Start() {
		unit = GetComponent<Unit>();
		if(!unit) {
			Debug.LogError("UnitMovement script attached to gameObject without unit");
			return;
		}

		unit.OnSelect.AddListener(OnSelect);
		unit.OnDeselect.AddListener(OnDeselect);
	}

	void OnSelect() {
		selected = true;
	}

	void OnDeselect() {
		if(!selected) {
			return;
		}
		RaycastHit hit;
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f, LayerMask.GetMask("Unit"))) {
			Unit target = hit.transform.GetComponent<Unit>();
			Charge(target);
		}
		else if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f, LayerMask.GetMask("Ground"))) {
			Vector3 desiredPos = hit.point;
			NormalMove(hit.point);
			// Advance(hit.point);
			// FallBack();
			// Ready();
		}
		selected = false;
	}

	void OnDestroy() {
		if(unit) {
			unit.OnSelect.RemoveListener(OnSelect);
			unit.OnDeselect.RemoveListener(OnDeselect);
		}
	}

	void NormalMove(Vector3 position) {
		if(Vector3.Distance(transform.position, position) < MoveSpeed) {
			transform.position = position;
		}
	}

	void Advance(Vector3 position) {
		int extraMove = d6.Roll();
		if(Vector3.Distance(transform.position, position) < MoveSpeed + extraMove) {
			transform.position = position;
		}
	}

	void FallBack() {
		int amount = d3.Roll();
		transform.position -= transform.forward * amount;
	}

	void Ready() {}

	void Charge(Unit target) {
		int maxDistance = d6.Total(2);
		Vector3 desiredPosition = Vector3.MoveTowards(
			transform.position,
			target.transform.position,
			Mathf.Min(
				Vector3.Distance(transform.position, target.transform.position) - unit.baseRadius - target.baseRadius,
				maxDistance
			)
		);
		transform.position = desiredPosition;
	}
}
