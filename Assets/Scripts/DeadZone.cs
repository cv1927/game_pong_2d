using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadZone : MonoBehaviour
{
    public Text scorePlayerText;
    public Text scoreEnemyText;

    int scorePlayerQuantity;
    int scoreEnemyQuantity;

    public SceneChange sceneChange;
    public AudioSource audioPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Right"))
        {
            scorePlayerQuantity++;
            UpdateScoreLabel(scorePlayerText, scorePlayerQuantity);
            audioPoint.Play();
            CheckScore();
        } else if (gameObject.CompareTag("Left"))
        {
            scoreEnemyQuantity++;
            UpdateScoreLabel(scoreEnemyText, scoreEnemyQuantity);
            audioPoint.Play();
            CheckScore();
        }

        collision.GetComponent<BallBehaviour>().gameStarted = false;
    }

    void UpdateScoreLabel(Text label, int score)
    {
        label.text = score.ToString();
    }

    void CheckScore()
    {
        if (scorePlayerQuantity == 3)
        {
            sceneChange.ChangeSceneTo("WinScene");
        } else if (scoreEnemyQuantity == 3)
        {
            sceneChange.ChangeSceneTo("LoseScene");
        }
    }
}
