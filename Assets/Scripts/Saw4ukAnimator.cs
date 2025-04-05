using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Saw4ukAnimator : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private List<Sprite> sprites;
        [SerializeField] private float secondsBetweenSprites;

        private int cadrNumber = 0;

        private void Awake()
        {
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