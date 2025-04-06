using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneTransition : MonoBehaviour
    {
        public void LoadMenuScene()
        {
            SceneManager.LoadScene(SceneNames.MainMenuScene);
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene(SceneNames.GameScene);
        }

        public void LoadTutorialScene()
        {
            SceneManager.LoadScene(SceneNames.TutorialScene);
        }

        public void LoadWinScene()
        {
            SceneManager.LoadScene(SceneNames.WinScene);
        }

        public void LoadLooseScene()
        {
            SceneManager.LoadScene(SceneNames.LooseScene);
        }
    }
}