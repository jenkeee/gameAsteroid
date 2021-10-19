using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    public Transform _mainMenu;
    [SerializeField]
    public Transform _settingMenu;
    [SerializeField]
    public Transform _quitConformation;

    public void PlayNewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        //Debug.Log("нажал выход");
        Application.Quit();
    }

    public void SettingMenu()
    {
        _mainMenu.gameObject.SetActive(false);
        _settingMenu.gameObject.SetActive(true);
    }

    public void BackToMain()
    {
        _mainMenu.gameObject.SetActive(true);
        _settingMenu.gameObject.SetActive(false);
        _quitConformation.gameObject.SetActive(false);
    }
    public void btnExit()
    {
        _quitConformation.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //&& !_mainMenu.gameObject.activeSelf
        {
            if (_quitConformation.gameObject.activeSelf || _settingMenu.gameObject.activeSelf)
            {
                _mainMenu.gameObject.SetActive(true);
                _settingMenu.gameObject.SetActive(false);
                _quitConformation.gameObject.SetActive(false);
            }
        }
    }

}
