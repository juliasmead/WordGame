using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GenerateLetters : MonoBehaviour {

    private TextMeshProUGUI text;
    private string letters;
    private int letterCount = 16;
    public string Letters {
        get {
            return letters;
        }
        set {
            letters = value;
            text.text = SortString(letters);
        }
    }

	private void Awake()
	{
        text = GetComponent<TextMeshProUGUI>();
        GenerateLetterPool();
	}

    private void GenerateLetterPool() {
        letters = "";
        for (int i = 0; i < letterCount; i++)
        {
            string st = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char c = st[UnityEngine.Random.Range(0, 25)];
            letters = letters + c;
        }
           text.text = SortString(letters);
    }

    static string SortString(string input)
    {
        char[] characters = input.ToCharArray();
        Array.Sort(characters);
        return new string(characters);
    }
}
