using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class TimerClass : MonoBehaviour
{
    public static TimerClass timerInst;
    public static string gamemode = "MENU";
    public TMP_Text timertext;
    public TMP_Text finishtime;
    public TMP_Text fintime;
    float millisec = 0.0f;
    public float seconds = 0.0f;
    float enemytimer = 10.0f;
    public TMP_Text etimer;
    public float minutes;
    public GameObject rpointerUI;
    public GameObject Enemygob;
    public GameObject playergob;
    public GameObject GameOver;
    public GameObject Menu;
    public GameObject Hud;
    public GameObject win;
    public GameObject leaderboard;

    public List<TMP_Text> scoreList;

    public void changeScreenFun(string name)
    {
        switch (name)
        {
            case "MENU":
                Menu.SetActive(true);
                Hud.SetActive(false);
                rpointerUI.SetActive(false);
                GameOver.SetActive(false);
                gamemode = "MENU";
                break;
            case "HUD":
                Menu.SetActive(false);
                Hud.SetActive(true);
                gamemode = "PLAY";
                PlayerMOvement.playerinst.playerposition();
                rpointerUI.SetActive(false);
                break;
            case "GO":
                finishtime.text = minutes + " : " + seconds;
                Menu.SetActive(false);
                Hud.SetActive(false);
                GameOver.SetActive(true);
                rpointerUI.SetActive(true);
                gamemode = "GO";
                PlayerMOvement.playerinst.initialposition();
                break;
            case "WIN":
                fintime.text = minutes + " : " + seconds;
                Menu.SetActive(false);
                Hud.SetActive(false);
                GameOver.SetActive(false);
                rpointerUI.SetActive(true);
                win.SetActive(true);
                gamemode = "WIN";
                PlayerMOvement.playerinst.initialposition();
                break;
            case "LB":
                Menu.SetActive(false);
                Hud.SetActive(false);
                GameOver.SetActive(false);
                rpointerUI.SetActive(false);
                win.SetActive(false);
                leaderboard.SetActive(true);
                gamemode = "LB";
                PlayerMOvement.playerinst.initialposition();
                SaveData.saveDataInst.scoreList();
                Debug.Log("lb"+ SaveData.saveDataInst.scoreArray.Count);
                SaveData.saveDataInst.scoreArray.Sort();
                for (int i=0;i<SaveData.saveDataInst.scoreArray.Count;i++)
                {
                    scoreList[i].transform.gameObject.SetActive(true);
                    scoreList[i].text = "" + SaveData.saveDataInst.scoreArray[i];
                    Debug.Log("lb");

                }

                break;

        }
    }
    private void Awake()
    {
        timerInst = this;
    }
    void Update()
    {
        if (gamemode == "PLAY")
        {

            if (millisec < 1)
            {
                //timertext.text = ( )
                millisec += Time.deltaTime;

            }
            else
            {
                millisec = 0;
                seconds++;
                enemytimer--;
                if (seconds == 60.0f)
                {
                    minutes++;
                    seconds = 0.0f;
                }

            }
            if (enemytimer == 0.0f)
            {
                enemytimer = 10.0f;
                GameObject gob = Instantiate(Enemygob) as GameObject;
                gob.GetComponent<enemy>().target = playergob;
            }
            timertext.text = minutes + " : " + seconds;
            etimer.text = enemytimer.ToString("0");
            // Enemygob.GetComponent<NavMeshAgent>().SetDestination(playergob.transform.position);
        }
    }
   
}
