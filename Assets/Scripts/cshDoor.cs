using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class cshDoor : MonoBehaviour
{
    public Image LoadingBar;
    private bool IsOn;
    private float barTime = 0.0f;

    public int itemCount = 0;

    private float timer = 1.0f;

    public bool flag;

    private GameObject Player;
    private Transform PlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        IsOn = false;
        LoadingBar.fillAmount = 0;

        flag = false;

        Player = GameObject.Find("Player");
        PlayerPos = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag && itemCount == 2)
        {
            PlayerPos.position = new Vector3(-3.0f, 1.45f, -0.52f);
            PlayerPos.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            Player.GetComponent<cshShowExplain>().phase = 7;
            Player.GetComponent<cshShowExplain>().IsOn = true;
            flag = false;
            itemCount++;
        }

        if (!flag && Player.GetComponent<cshShowExplain>().phase == 8)
        {
            this.GetComponent<BoxCollider>().enabled = true;
        }

        if (IsOn)
        {
            if (barTime <= 2.0f)
            {
                barTime += Time.deltaTime;
            }
            else
            {
                flag = true;
                GameObject.Find("Door").GetComponent<BoxCollider>().enabled = false;
                //GameObject.Find("Player").GetComponent<cshShowExplain>().phase = 9;
            }
            LoadingBar.fillAmount = barTime / 2.0f;
        }

        if (flag)
        {
            if (PlayerPos.position.x <= -1.94f)
            {
                PlayerPos.Translate(new Vector3(0.5f * Time.deltaTime, 0.0f, 0.0f));
            }
            else if (PlayerPos.position.z <= 1.45f)
            {
                PlayerPos.Translate(new Vector3(0.0f, 0.0f, 0.5f * Time.deltaTime));
            }
            else
            {
                if (timer <= 0.0f)
                {
                    flag = false;
                    Player.GetComponent<cshShowExplain>().IsOn = true;
                    //this.GetComponent<BoxCollider>().enabled = false;
                }
                else
                {
                    this.transform.Rotate(0.0f, 0.0f, -90.0f * Time.deltaTime);
                    timer -= Time.deltaTime;
                }
            }
        }
    }

    public void SetGazedAt(bool gazedAt)
    {
        IsOn = gazedAt;
        barTime = 0.0f;
        if (gazedAt)
        {
            Debug.Log("In");
        }
        else
        {
            Debug.Log("Out");
            LoadingBar.fillAmount = 0;
        }
    }
}
