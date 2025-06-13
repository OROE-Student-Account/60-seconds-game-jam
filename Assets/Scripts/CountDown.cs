using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{

    public float defaultTimeLeft = 60f;

    public Timer timer;

    public GameObject sceneChanger;

    public string[] scene;

    void Start()
    {
        timer = new Timer(defaultTimeLeft);
        // Adds the OnTimeUp code to the TimeUp function
        timer.TimeUp += OnTimeUp;
    }

    void Update() => timer.Update();

    void OnTimeUp()
    { 
        sceneChanger.GetComponent<SceneChanger>().ChangeScene(scene[UnityEngine.Random.Range(0,scene.Length)]);
    }
}

public class Timer
{
    public delegate void TimeUpHandler();
    public event TimeUpHandler TimeUp;

    public float TimeLeft { get; protected set; }

    // Like constructor in js
    public Timer(float timeLeftSeconds)
    {
        TimeLeft = timeLeftSeconds;
    }

    public void Update()
    {
        TimeLeft -= Time.deltaTime;

        if (TimeLeft <= 0)
        {
            OnTimeUp();
        }
    }

    public void AddTime(float seconds)
    {
        TimeLeft += seconds;
    }

    protected virtual void OnTimeUp()
    {
        TimeUp?.Invoke();
    }
}