using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData saveDataInst;
    string currentTimerName = "";
   public List<float> scoreArray;
    bool listUpdated = false;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        saveDataInst = this;
        if (!PlayerPrefs.HasKey("t1"))
        {
            for (int i = 1; i < 6 ; i++)
            {
                PlayerPrefs.SetFloat("t" + i, 0);
                Debug.Log(PlayerPrefs.GetFloat("t"+i));
            }
            currentTimerName = "t1";
        }
        else
        {

            for (int i = 1; i < 6; i++)
            {
                float val = PlayerPrefs.GetFloat("t" + i);
                if (val == 0)
                {
                    currentTimerName = "t" + i;
                    break;
                }
                //Debug.Log("size : "+currentTimerName.Length);
            }
            if (currentTimerName.Length == 0)
            {
                currentTimerName = "t6";
            }
        }
        Debug.Log("Current name : " + currentTimerName);
    }
    public void SaveDataFun(float time)
    {
        if (currentTimerName == "t6")
        {

            for (int i = 1; i < 6; i++)
            {
                if (PlayerPrefs.GetFloat("t" + i) > PlayerPrefs.GetFloat("t6"))
                {
                   
                    PlayerPrefs.SetFloat("t" + i, PlayerPrefs.GetFloat("t6"));
                    break;
                }
            }

            listUpdated = false;
            scoreList();
            listUpdated = true;
            scoreArray.Sort();
           // scoreArray[scoreArray.Count - 1] = time;
           // PlayerPrefs.SetFloat("t5", time);
        }
        else
        {
            PlayerPrefs.SetFloat(currentTimerName, time);
            Debug.Log("Game Over :: Time : "+ time);
        }

    }
    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        scoreList();
    //    }
    //}
    public void scoreList()
    {
       if(listUpdated == false)
        {
            scoreArray = new List<float>();
            for (int i = 0, j = 1; i < 5; i++, j++)
            {
                string key = "t" + j;

                if (PlayerPrefs.HasKey(key))
                {
                    float val = PlayerPrefs.GetFloat(key);
                    Debug.Log(key + "  : T : " + val);
                    if (val != 0)
                    {
                        scoreArray.Add(val);
                        // break;
                    }
                }
                else
                {
                    Debug.Log("Nokey : " + key);
                }
            }
        }
       
    }
}
