using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class cshShoes : MonoBehaviour
{
    public Image LoadingBar;
    private bool IsOn;
    private float barTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        IsOn = false;
        LoadingBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<cshShowExplain>().phase == 9)
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
                this.GetComponent<BoxCollider>().enabled = false;
                Destroy(GameObject.Find("Shoes"));
                GameObject.Find("Player").GetComponent<cshShowExplain>().IsOn = true;
                barTime = 0.0f;
            }
            LoadingBar.fillAmount = barTime / 2.0f;
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
