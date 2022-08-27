using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBag : MonoBehaviour
{
    public int itemCount = 0;

    private float time = 0.0f;
    private bool IsOn;

    public Transform BagNewPos;

    // Start is called before the first frame update
    void Start()
    {
        IsOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOn)
        {
            if (itemCount == 8)
            {
                if (time <= 1.0f)
                {
                    time += Time.deltaTime;
                }
                else
                {
                    IsOn = false;
                    this.transform.position = BagNewPos.position;
                    GameObject.Find("Player").GetComponent<cshShowExplain>().IsOn = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        Destroy(coll.gameObject);
    }
}
