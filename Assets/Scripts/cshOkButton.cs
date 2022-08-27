using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class cshOkButton : MonoBehaviour
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
        if (IsOn)
        {
            if (barTime <= 1.0f)
            {
                barTime += Time.deltaTime;
            }
            else
            {
                Destroy(GameObject.Find("Explain(Clone)"));
                GameObject.Find("Player").GetComponent<cshShowExplain>().phase++;
            }
            LoadingBar.fillAmount = barTime / 1.0f;
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
