using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Orderer
{
    public class IraqTextPrinter : MonoBehaviour
    {
        [SerializeField] private TMP_Text textField;
        [SerializeField] private float timeBetweenLettersInSeconds;

        public UnityEvent textWritten;

        private void Awake()
        {
            var test = textField.text;
            textField.text = "";
            WriteText(test);
        }

        public void WriteText(string text)
        {
            StopAllCoroutines();
            StartCoroutine(WritingTextCoroutine(text));
        }

        private IEnumerator WritingTextCoroutine(string text)
        {
            var builder = new StringBuilder();
            foreach (var chr in text)
            {
                builder.Append(chr);
                textField.text = builder.ToString();
                yield return new WaitForSeconds(timeBetweenLettersInSeconds);
            }
            textWritten.Invoke();
        }
    }
}