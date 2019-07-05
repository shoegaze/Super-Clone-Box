
public class GroundCheck : WorldCheck {

  public bool IsGrounded {
    get {
      return Touching > 0;
    }
  }

  private void Awake() {
    CheckTag = "Ground";
  }
  
}
