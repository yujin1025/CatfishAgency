using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneMgr : SingletonBehaviour<SceneMgr>
{
    
    public enum Scene // 씬의 이름이 담깁니다.
    {
        None = 0,
        StartScene,
        PrologueScene,
        MainScene,
        MainScene1,
        StoryScene,
        MapScene,
        EndingScene
    }

    public Scene _currScene = Scene.None;

    
    private new void Awake() // SceneMgr이 가장 먼저 생성됨
    {
        base.Awake();
        _currScene = scenemapByString[SceneManager.GetActiveScene().name];
    }

    public static Dictionary<string, Scene> scenemapByString = new Dictionary<string, Scene>()
    {
        {"StartScene", Scene.StartScene},
        {"PrologueScene", Scene.PrologueScene},
        {"MainScene", Scene.MainScene},
        {"MainScene", Scene.MainScene1},
        {"StoryScene", Scene.StartScene},
        {"MapScene", Scene.MapScene},
        {"EndingScene", Scene.EndingScene}
    };

    public static Dictionary<Scene, string> scenemapByEnum = new Dictionary<Scene, string>()
    {
        {Scene.StartScene, "StartScene"},
        {Scene.PrologueScene, "PrologueScene"},
        {Scene.MainScene, "MainScene"},
        {Scene.MainScene, "MainScene1"},
        {Scene.StartScene, "StoryScene"},
        {Scene.MapScene, "MapScene"},
        {Scene.EndingScene, "EndingScene"}
    };

    public void LoadScene(Scene sceneEnum, Action<float> onSceneLoad = null)
    {
        _currScene = sceneEnum;
        SceneManager.sceneLoaded += LoadSceneEnd;
        StartCoroutine(OnLoadSceneCoroutine(sceneEnum, onSceneLoad));
    }


    private IEnumerator OnLoadSceneCoroutine(Scene SceneEnum, Action<float> onSceneLoad)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(SceneEnum.ToString(), LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;

        //UIMgr.Instance.TurnOnSceneLoadUI(); // 씬 로딩을 시작하면, 씬 로더 뷰를 생성함

        while (asyncOperation.progress < 0.9f)
        {
            yield return null;

            if (onSceneLoad != null)
                onSceneLoad(asyncOperation.progress);
        }

        asyncOperation.allowSceneActivation = true;
    }

    private void LoadSceneEnd(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        if (scene.name == _currScene.ToString())
        {
            //UIMgr.Instance.TurnOffSceneLoadUI();
        }
    }
    
}
