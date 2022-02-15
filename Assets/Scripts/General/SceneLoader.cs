using UnityEngine;
using UnityEngine.SceneManagement;

namespace General
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(int loadScene)
        {
            SceneManager.LoadScene(loadScene);
        }
    }
}
