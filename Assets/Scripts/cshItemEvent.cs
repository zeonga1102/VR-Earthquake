using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class cshItemEvent : MonoBehaviour
{
    public Image LoadingBar;
    private bool IsOn;
    private float barTime = 0.0f;

    private Text ItemText;
    public string text;
    public Transform ItemName;
    public Transform ItemNamePos;

    public Transform BagPos;

    private bool flag;

    void Start()
    {
        IsOn = false;
        LoadingBar.fillAmount = 0;

        flag = true;
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
                if(flag)
                {
                    flag = false;
                    this.transform.position = new Vector3(BagPos.position.x, BagPos.position.y + 1.0f, BagPos.position.z);
                    this.GetComponent<Collider>().isTrigger = true;
                    GameObject.Find("Backpack").GetComponent<cshBag>().itemCount++;
                }
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
            Instantiate(ItemName, ItemNamePos.position, ItemNamePos.rotation);
            ItemText = GameObject.Find("ItemText").GetComponent<Text>();
            ItemText.text = text;
            Debug.Log("In");
        }
        else
        {
            Destroy(GameObject.Find("ItemName(Clone)"));
            Debug.Log("Out");
            LoadingBar.fillAmount = 0;
        }
    }
}
