using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneTransition : MonoBehaviour
    {
        public void LoadGameScene()
        {
            SceneManager.LoadScene(SceneNames.GameScene);
        }
    }
}