using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class Saw4ukAnimatorForImage : MonoBehaviour
    {
        [SerializeField] private Image spriteRenderer;
        [SerializeField] private List<Sprite> sprites;
        [SerializeField] private float secondsBetweenSprites;

        private int cadrNumber = 0;

        private void OnEnable()
        {
            StopAllCoroutines();
            StartCoroutine(Coroutine());
        }

        private IEnumerator Coroutine()
        {
            while (true)
            {
                spriteRenderer.sprite = sprites[cadrNumber];
                cadrNumber += 1;
                if (cadrNumber == sprites.Count)
                    cadrNumber = 0;
                yield return new WaitForSeconds(secondsBetweenSprites);
            }
        }
    }
}