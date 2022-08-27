using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshWakeupPlayer : MonoBehaviour
{
    public bool IsOn;
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
        if (IsOn)
        {
            if(this.GetComponent<cshShowExplain>().phase == 2)
            {
                if (this.transform.position.y <= 1.45f)
                {
                    this.transform.Translate(new Vector3(0.0f, 0.5f * Time.deltaTime, 0.0f));
                }
                else if(!flag)
                {
                    IsOn = false;
                    flag = true;
                    this.GetComponent<cshShowExplain>().IsOn = true;
                }
            }
            else if (flag && this.GetComponent<cshShowExplain>().phase == 3)
            {
                IsOn = false;
                this.GetComponent<cshShowExplain>().IsOn = true;
            }
        }
    }
}
