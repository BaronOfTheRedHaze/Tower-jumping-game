using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //PlayerControls.instance.RB.velocity = new Vector2(PlayerControls.instance.RB.velocity.x * 5, PlayerControls.instance.RB.velocity.y);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //PlayerControls.instance.RB.velocity = new Vector2(PlayerControls.instance.RB.velocity.x *2, PlayerControls.instance.RB.velocity.y);
        }
    }




}
