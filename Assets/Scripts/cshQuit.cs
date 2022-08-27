using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshQuit : MonoBehaviour
{
    public bool IsOn;

    private float timer = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        IsOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<cshShowExplain>().phase == 10 && IsOn)
        {
            if (timer <= 0.0f)
            {
                this.GetComponent<cshShowExplain>().IsOn = true;
                this.GetComponent<cshShowExplain>().phase = 11;
                IsOn = false;
                timer = 1.0f;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

        if (this.GetComponent<cshShowExplain>().phase == 12 && IsOn)
        {
            if (timer <= 0.0f)
            {
                this.GetComponent<cshShowExplain>().IsOn = true;
                IsOn = false;
            }
            else
            {
                timer-=Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
