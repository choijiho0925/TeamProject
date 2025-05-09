using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlaskType
{
    Red,
    Blue
}

public class Flask : MonoBehaviour
{
    public FlaskType flasktype;
    public LayerMask firePlayerLayer;
    public LayerMask waterPlayerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int objLayer = collision.gameObject.layer;

        bool isPlayerF = (firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0;
        bool isPlayerW = (waterPlayerLayer.value & (1 << collision.gameObject.layer)) != 0;

        switch (flasktype)
        {
            case FlaskType.Red:
                if (isPlayerF)
                {
                    Debug.Log("Åü»çÈÄ¸£°¡ »¡°­ ÇÃ¶ó½ºÅ©¸¦ È¹µæ");
                    Destroy(gameObject);
                    // Red Flask È¹µæ ¼ö 1 Ãß°¡
                }
                break;

            case FlaskType.Blue:
                if (isPlayerW)
                {
                    Debug.Log("Å¸»çÈÄ¸£°¡ ÆÄ¶û ÇÃ¶ó½ºÅ©¸¦ È¹µæ");
                    Destroy(gameObject);
                    // Blue Flask È¹µæ ¼ö 1 Ãß°¡
                }
                break;
        }
    }
}
