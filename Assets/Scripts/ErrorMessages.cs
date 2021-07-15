using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains useful error messages that might come up
/// </summary>
public static class ErrorMessages
{
    public static void NullMessage(GameObject currentObject)
    {
        Debug.LogError($"Error: A script on {currentObject.name} is missing information", currentObject);
        throw new NullReferenceException();
    }
}
