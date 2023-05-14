using UnityEngine;
using UnityEngine.SceneManagement;

namespace HUD.Menu
{
    public class SceneLoader: MonoBehaviour {

        public void ChangeScene(int idScene)
        {
            SceneManager.LoadScene(idScene);
        }
    
    }
}