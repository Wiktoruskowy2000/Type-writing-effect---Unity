using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWriting : MonoBehaviour
{
    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;
    [SerializeField] string leadingChar = "";
    [SerializeField] bool leadingCharBeforeDelay = false;

    private TMP_Text _tmpProText;
    private string _text;

    private void OnEnable()
    {
        _tmpProText = GetComponent<TMP_Text>();
        _text = _tmpProText.text;
        _tmpProText.text = "";
        StartCoroutine(TypeWriterTMP());
    }


    IEnumerator TypeWriterTMP()
    {
        _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in _text)
        {
            if (_tmpProText.text.Length > 0)
            {
                _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
            }
            _tmpProText.text += c;
            _tmpProText.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        if (leadingChar != "")
        {
            _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
        }
    }
}