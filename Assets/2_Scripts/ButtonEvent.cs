using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public void SceneLoader(string sceneName)               // 적혀진 이름이 있는 곳으로 씬 이동함.
    {
        SceneManager.LoadScene(sceneName);
    }
}
