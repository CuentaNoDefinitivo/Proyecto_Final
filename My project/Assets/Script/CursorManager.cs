using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {
        if(Cursor.visible) Cursor.visible = false;
    }
}
