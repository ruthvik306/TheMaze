using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMOvement : MonoBehaviour
{

    public static PlayerMOvement playerinst;
    public float speed;
    public GameObject targetdir;
    Rigidbody rbd;
    public Transform health;
    private Vector3 initialpos;
    private float hp;
    void Start()
    {
        
        initialpos = transform.position;
        playerinst = this;
        hp = 1.0f;
        rbd = GetComponent<Rigidbody>();
        health.GetComponent<Image>().fillAmount = hp;
        Debug.Log(hp);
    }
    
    void FixedUpdate()
    {
        if (TimerClass.gamemode == "PLAY")
        {
            //Vector3 v_ = new Vector3(player.transform.forward.x, 0, player.transform.forward.z);
            //transform.position += v_ * speed * Time.deltaTime;
            Vector3 dirvector = new Vector3(targetdir.transform.forward.x, 0, targetdir.transform.forward.z);
            rbd.AddForce(dirvector * speed);
            health.GetComponent<Image>().fillAmount = hp;
            if (hp < 0.42f)
            {
                TimerClass.timerInst.changeScreenFun("GO");
            }
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
            hp = hp - 0.15f;
        if (collision.gameObject.tag == "END")
        {
            TimerClass.timerInst.changeScreenFun("WIN");
            float secValue = TimerClass.timerInst.minutes*60 + TimerClass.timerInst.seconds;
            SaveData.saveDataInst.SaveDataFun(secValue);
        }

    }


    public void playerposition()
    {
        transform.position = new Vector3(transform.position.x, 2, transform.position.z);
    }
    public void initialposition()
    {
        transform.position = new Vector3(47.01f, -297.85f, -40.085f);
    }

}
