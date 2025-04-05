using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Orderer
{
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private List<Orderer> orderers;

        public IEnumerable<Orderer> Orderers => orderers;
    }
}