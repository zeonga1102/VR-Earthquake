using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class cshFuseBox : MonoBehaviour
{
    public Image LoadingBar;
    private bool IsOn;
    private float barTime = 0.0f;

    private GameObject Player;
    private Transform PlayerPos;
    private Vector3 position;
    private Quaternion rotation;

    private float timer1 = 1.0f;
    private float timer2 = 1.0f;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        IsOn = false;
        LoadingBar.fillAmount = 0;

        Player = GameObject.Find("Player");

        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOn)
        {
            if (barTime <= 2.0f)
            {
                barTime += Time.deltaTime;
            }
            else
            {
                if(!flag)
                {
                    PlayerPos = Player.transform;
                    position = new Vector3(PlayerPos.position.x, PlayerPos.position.y, PlayerPos.position.z);
                    rotation = Quaternion.Euler(PlayerPos.rotation.x, PlayerPos.rotation.y, PlayerPos.rotation.z);

                    Player.transform.position = new Vector3(-4.0f, 1.55f, -1.8f);
                    Player.transform.rotation = Quaternion.Euler(0.0f, 10.0f, 0.0f);

                    this.GetComponent<BoxCollider>().enabled = false;

                    flag = true;

                    GameObject.Find("Door").GetComponent<cshDoor>().itemCount++;
                }
            }
            LoadingBar.fillAmount = barTime / 2.0f;
        }

        if (flag)
        {
            if (timer1 <= 0.0f)
            {
                if (timer2 <= 0.0f)
                {
                    flag = false;

                    if(GameObject.Find("Door").GetComponent<cshDoor>().itemCount == 1)
                    {
                        PlayerPos.position = position;
                        PlayerPos.rotation = rotation;
                    }

                    if (GameObject.Find("Door").GetComponent<cshDoor>().itemCount == 2)
                    {
                        GameObject.Find("Door").GetComponent<cshDoor>().flag = true;
                    }
                }
                else
                {
                    timer2 -= Time.deltaTime;
                }

            }
            else
            {
                timer1 -= Time.deltaTime;
                this.transform.Rotate(0.0f, 180.0f * Time.deltaTime, 0.0f);
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
