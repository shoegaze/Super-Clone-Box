
public class WallCheck : WorldCheck {

  public bool IsBlocked {
    get {
      return Touching > 0;
    }
  }

  private void Awake() {
    CheckTag = "Ground";
  }

}
