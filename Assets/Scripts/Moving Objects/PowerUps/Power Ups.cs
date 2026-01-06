using UnityEngine;

public class PowerUps : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }

        PickUp();
    }
    protected virtual void PickUp()
    {
        //Update the ui
        //Have effect to indicate power up
        //Update the event to do the power up to player

        Destroy(gameObject);
    }
}
