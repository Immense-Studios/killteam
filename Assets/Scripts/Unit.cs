using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, ISelectable {

	public int WeaponSkill;
	public int BallisticSkill;
	public int Strength;
	public int Toughness;
	public int Wounds;
	public int Initiative;
	public int Attacks;
	public int Leadership;
	public int ArmorSave;
	public float baseRadius = .05f;

	public List<Weapon> weapons;
	public SelectionEvent OnSelect = new SelectionEvent();
	public SelectionEvent OnDeselect = new SelectionEvent();

	public void Select() {
		OnSelect.Invoke();
	}
	public void Deselect() {
		OnDeselect.Invoke();
	}
}
