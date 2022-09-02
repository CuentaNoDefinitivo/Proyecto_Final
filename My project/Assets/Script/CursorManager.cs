using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Texture2D cursorTexture2D;
    [SerializeField] Vector2 ofset;
    void Start()
    {
        Cursor.SetCursor(cursorTexture2D,ofset,CursorMode.Auto);
    }
}
