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
        public void LoadTutorialScene()
        {
            SceneManager.LoadScene(SceneNames.TutorialScene);
        }
    }
}