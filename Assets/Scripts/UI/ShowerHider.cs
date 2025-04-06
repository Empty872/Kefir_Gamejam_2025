using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class ShowerHider : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        public void Show()
        {
            animator.SetTrigger("Show");
        }
    }
}