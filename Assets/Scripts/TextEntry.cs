using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEntry : MonoBehaviour
{
    private string chars = "AABC";

    private TMP_InputField field;

    private string oldValue = "";

    private void Awake()
    {
        field = GetComponent<TMP_InputField>();
        field.onValidateInput = delegate (string input, int charIndex, char addedChar)
        {
            return ValidateChar(addedChar);
        };
        field.onValueChanged.AddListener(delegate { AddBackChar(); });
    }

    private char ValidateChar(char c)
    {
        c = char.ToUpper(c);
        if (!chars.Contains(c.ToString()))
        {
            c = '\0';
        }
        else
        {
            chars =  chars.Remove(chars.IndexOf(c), 1);
        }
        return c;
    }

    private void AddBackChar()
    {
        if (oldValue.Length > field.text.Length)
        {
            chars += oldValue.Remove(oldValue.IndexOf(field.text), field.text.Length);
        }

        oldValue = field.text;
    }
}
