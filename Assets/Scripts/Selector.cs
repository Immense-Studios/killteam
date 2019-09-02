using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SelectionEvent: UnityEvent {}

public interface ISelectable {
  void Select();
  void Deselect();
}

public class Selector: MonoBehaviour {

  public Camera cam;
  public ISelectable selected;
  private float raycastDistance = 1000f;

  void Update() {
    if(!Input.GetMouseButtonDown(0)) {
      return;
    }
    RaycastHit hit;
    if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit)) {
      ISelectable selection = hit.transform.GetComponent<ISelectable>();
      if(selection != null) {
        if(selected != null) {
          selected.Deselect();
        }
        selected = selection;
        selected.Select();
      } else {
        // Hit something, but nothing selectable.
        if(selected != null) {
          selected.Deselect();
        }
        selected = null;
      }
    }
  }
}
