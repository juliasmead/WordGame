using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEntry : MonoBehaviour
{
    private TMP_InputField field;

    private string oldValue = "";

    public GenerateLetters gl;

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
        if (!gl.Letters.Contains(c.ToString()))
        {
            c = '\0';
        }
        else
        {
            gl.Letters =  gl.Letters.Remove(gl.Letters.IndexOf(c), 1);
        }
        return c;
    }

    private void AddBackChar()
    {
        if (oldValue.Length > field.text.Length)
        {
            gl.Letters += oldValue.Remove(oldValue.IndexOf(field.text), field.text.Length);
        }

        oldValue = field.text;
    }
}
