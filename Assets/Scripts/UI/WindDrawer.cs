using UnityEngine;

namespace DefaultNamespace.UI
{
    public class WindDrawer : MonoBehaviour
    {
        [SerializeField] private GameObject l3;
        [SerializeField] private GameObject l2;
        [SerializeField] private GameObject l1;
        [SerializeField] private GameObject o;
        [SerializeField] private GameObject r1;
        [SerializeField] private GameObject r2;
        [SerializeField] private GameObject r3;
        
        public void Start()
        {
            Draw();
            Environment.Instance.OnChanged += InstanceOnOnChanged;
        }

        private void InstanceOnOnChanged(int arg1, int arg2)
        {
            Draw();
        }

        public void Draw()
        {
            l3.gameObject.SetActive(false);
            l2.gameObject.SetActive(false);
            l1.gameObject.SetActive(false);
            o.gameObject.SetActive(false);
            r1.gameObject.SetActive(false);
            r2.gameObject.SetActive(false);
            r3.gameObject.SetActive(false);
            
            switch (Environment.Instance.WindSpeed)
            {
                case -3 :
                    l3.gameObject.SetActive(true);
                    return;
                case -2:
                    l2.gameObject.SetActive(true);
                    return;
                case -1:
                    l1.gameObject.SetActive(true);
                    return;
                case 0:
                    o.gameObject.SetActive(true);
                    return;
                case 1:
                    r1.gameObject.SetActive(true);
                    return;
                case 2:
                    r2.gameObject.SetActive(true);
                    return;
                case 3:
                    r3.gameObject.SetActive(true);
                    return;
            }
        }
    }
}