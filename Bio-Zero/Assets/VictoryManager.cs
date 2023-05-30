using System.Collections;
using System.Collections.Generic;
using HUD.Menu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nickname;
    private SceneLoader sceneL;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        sceneL = FindObjectOfType<SceneLoader>();
        nickname.text = DataManager.DataManager.instance.GetPlayer().nickname;
    }

    public void GoToHome()
    {
        Destroy(DataManager.DataManager.instance);
        sceneL.ChangeScene(0);
    }
}
