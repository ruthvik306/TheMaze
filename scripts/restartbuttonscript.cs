using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restartbuttonscript : MonoBehaviour
{
    public float timer = 0f;

    public Transform radialtimer;
    public bool var = false;
    void Start()
    { 
        radialtimer.GetComponent<Image>().fillAmount = timer;

    }
    public void Update()
    {
        if (var)
            timer = timer + Time.deltaTime;
        radialtimer.GetComponent<Image>().fillAmount = timer;
    }
    public void toZero()
    {
        timer = 0f;

    }
    public void OnGaze()
    {
        StartCoroutine(lookStart());
        StartCoroutine(UIchanger());
        radialtimer.GetComponent<Image>().fillAmount = timer;

    }
    public void OffGaze()
    {
        toZero();
        var = false;
        StopAllCoroutines();
        radialtimer.GetComponent<Image>().fillAmount = 0.0f;
    }
    IEnumerator lookStart()
    {
        var = true;
        yield return new WaitForSeconds(3f);
        if (var)
            StartCoroutine(UIchanger());
        var = false;
    }
    IEnumerator UIchanger()
    {
        yield return new WaitForSeconds(3f);
        //Debug.Log("working");
        SceneManager.LoadScene("main");
    }
}
