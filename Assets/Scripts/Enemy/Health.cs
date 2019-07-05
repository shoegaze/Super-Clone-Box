using UnityEngine;

public class Health : MonoBehaviour {
  [SerializeField]
  uint health;

  public bool IsDead {
    get {
      return health == 0;
    }
  }
  
  private void Update() {
    if (IsDead) {
      Kill();
    }
  }

  private void Kill() {
    Destroy(gameObject, 0.0f);
  }
  
  public void Take(uint dmg) {
    if (dmg >= health) {
      health = 0;
    }
    else {
      health -= dmg; 
    }
  }

}
