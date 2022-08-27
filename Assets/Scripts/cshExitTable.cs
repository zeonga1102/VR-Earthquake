using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshExitTable : MonoBehaviour
{
    public bool IsOn;

    private float time = 1.0f;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        IsOn = false;
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsOn)
        {
            if(this.GetComponent<cshShowExplain>().phase == 5)
            {
                if (this.transform.position.x >= -3.0f)
                {
                    this.transform.Translate(new Vector3(-0.5f * Time.deltaTime, 0.0f, 0.0f));
                }
                else if (this.transform.position.y <= 1.45f)
                {
                    this.transform.Translate(new Vector3(0.0f, 0.5f * Time.deltaTime, 0.0f));
                }
                else if(!flag)
                {
                    if (time <= 0.0f)
                    {
                        this.GetComponent<cshShowExplain>().IsOn = true;
                        IsOn = false;
                        flag = true;
                    }
                    else
                    {
                        time -= Time.deltaTime;
                    }
                }
            }
            else if (flag && this.GetComponent<cshShowExplain>().phase == 6)
            {
                IsOn = false;
                this.GetComponent<cshShowExplain>().IsOn = true;
            }
        }
    }
}
