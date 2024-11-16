using UnityEngine;

public class FruitAnimation : MonoBehaviour
{
    public Animator cherriesAnimator;  // The animator for the fruit's animation (cherries)
    public Animator scoreAnimator;     // The animator for the UI text (score)

    void Start()
    {
        // Automatically assigns the Animator for cherries if it's not set in the Inspector
        if (cherriesAnimator == null)
        {
            cherriesAnimator = GetComponent<Animator>();
        }

        // Automatically assign the scoreAnimator if it's not set
        if (scoreAnimator == null)
        {
            // Find the UI text animator in the scene (by tag or name)
            scoreAnimator = GameObject.Find("ScoreText").GetComponent<Animator>();
            // Alternatively, you can use FindWithTag if your UI text has a tag, like "UI"
            // scoreAnimator = GameObject.FindWithTag("UI").GetComponent<Animator>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Trigger the collected animation for the fruit (cherries)
            cherriesAnimator.SetTrigger("CollectedTrigger");

            // Trigger the UI animation (side to side movement)
            scoreAnimator.SetTrigger("ScoreRestTrigger");

            // Disable the fruit's collider so it can't be collected again
            GetComponent<Collider>().enabled = false;

            // Destroy the fruit after the animation has played
            Destroy(gameObject, 1f);  // Adjust the delay to match your fruit animation length
        }
    }
}
