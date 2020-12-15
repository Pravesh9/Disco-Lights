using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : Debug
{
    public static void LogWithColor(string _message, Color _color)
    {
        Debug debug = new Debug();
        debug.LogWithColor(_message, _color);
    }

}
