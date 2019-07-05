using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class WorldCheck : MonoBehaviour {
  private string _checkTag;
  private int _touching;

  protected string CheckTag {
    get {
      return _checkTag;
    }
    set {
      _checkTag = value;
    }
  }

  protected int Touching {
    get {
      return _touching;
    }
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.CompareTag(_checkTag)) {
      ++_touching;
    }
  }

  private void OnTriggerExit2D(Collider2D collision) {
    if (collision.CompareTag(_checkTag)) {
      --_touching;
    }
  }

}