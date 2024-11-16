using UnityEngine;

public class ScoreAnimation : MonoBehaviour
{
    public Animator scoreAnimator;

    void Start()
    {
        // Automatically assigns the Animator if it's not set in the Inspector
        if (scoreAnimator == null)
        {
            scoreAnimator = GetComponent<Animator>();
        }
    }

    // This method can be triggered by the FruitAnimation script when the cherry is collected
    public void TriggerScoreRestAnimation()
    {
        scoreAnimator.SetTrigger("ScoreRestTrigger");
    }
}