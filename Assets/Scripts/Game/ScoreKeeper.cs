using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
  [SerializeField]
  Text scoreLabel;
  [SerializeField]
  uint score;
  [SerializeField]
  uint highScore;

  //private GameController _game;

  public uint Score {
    get {
      return score;
    }
  }

  public uint HighScore {
    get {
      return highScore;
    }
    set {
      highScore = value;
    }
  }

  private void Awake() {
    ResetScore();
  }
  
  public void ResetScore() {
    score = 0;

    UpdateScoreLabel();
  }

  public void IncrementScore() {
    ++score;

    UpdateScoreLabel();
  }

  public void UpdateScoreLabel() {
    scoreLabel.text = "" + score;

    if (score > highScore) {
      scoreLabel.text += "!";
    }
  }

}
