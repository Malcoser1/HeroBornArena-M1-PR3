using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public float BoostMultiplier = 2.0f;
    public float BoostSeconds = 5.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("JUMP BOOOOST!");
            PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
            Player.BoostJump(BoostMultiplier, BoostSeconds);
        }
    }
}