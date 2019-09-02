using UnityEngine;

public class UnitAnimator: MonoBehaviour {

  public Animator anim;

  public void Select(bool selected) {
    anim.SetBool("Selected", selected);
  }

  public void Shoot() {
    anim.SetTrigger("Shoot");
  }
}