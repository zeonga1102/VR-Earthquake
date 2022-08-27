using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class cshGoTable : MonoBehaviour
{
    public bool IsOn;

    public Image LoadingBar;
    private bool BarIsOn;
    private float barTime = 0.0f;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        IsOn = false;

        BarIsOn = false;
        LoadingBar.fillAmount = 0;

        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(IsOn)
        {
            this.GetComponent<BoxCollider>().enabled = true;
            if (BarIsOn)
            {
                if (barTime <= 2.0f)
                {
                    barTime += Time.deltaTime;
                }
                else
                {
                    Player.transform.position = new Vector3(-1.86f, 0.26f, -0.45f);
                    Player.GetComponent<cshShakePlayer>().initialPosition = Player.transform.position;
                    IsOn = false;
                    Player.GetComponent<cshShowExplain>().phase++;
                }
                LoadingBar.fillAmount = barTime / 2.0f;
            }
        }
        else
        {
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void SetGazedAt(bool gazedAt)
    {
        BarIsOn = gazedAt;
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
