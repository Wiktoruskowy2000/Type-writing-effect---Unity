using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWriting : MonoBehaviour
{
    public float StartDelay = 0f;
    public float TypeSpeed = 0.1f;

    private string FrontChar = "";
    private bool CharBeforeDelay = false;

    private TMP_Text TMPText; // thisGameObject
    private string _text;       //temporary string with thisGameObject text

    private void OnEnable()
    {
        TMPText = GetComponent<TMP_Text>();
        _text = TMPText.text;               //send default text to temp (_text)
        TMPText.text = "";                  //set thisGameObject text to null
        StartCoroutine(TypeWriterTMP());
    }


    IEnumerator TypeWriterTMP()
    {
        TMPText.text = CharBeforeDelay ? FrontChar : "";

        yield return new WaitForSeconds(StartDelay);

        foreach (char _char in _text)
        {
            if (TMPText.text.Length > 0)
            {
                TMPText.text = TMPText.text.Substring(0, TMPText.text.Length - FrontChar.Length);
            }
            TMPText.text += _char;
            TMPText.text += FrontChar;
            yield return new WaitForSeconds(TypeSpeed);
        }

        if (FrontChar != "")
        {
            TMPText.text = TMPText.text.Substring(0, TMPText.text.Length - FrontChar.Length);
        }
    }
}

//Type writing ~By Proxima
