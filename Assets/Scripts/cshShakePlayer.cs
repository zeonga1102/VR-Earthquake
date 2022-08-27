using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshShakePlayer : MonoBehaviour
{
    public float ShakeAmount;

    public Vector3 initialPosition;

    public bool IsOn;
    private bool flag;

    private float shakeTime = 5.0f;

    private AudioSource audio;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        flag = true;

        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.clip;
        this.audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsOn)
        {
            if (flag)
            {
                flag = false;
                initialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                GameObject.Find("Table").GetComponent<cshGoTable>().IsOn = true;
                this.audio.Play();
            }
            else
            {
                transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
            }

            if (this.GetComponent<cshShowExplain>().phase == 4)
            {
                transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;

                if (shakeTime <= 0.0f)
                {
                    this.GetComponent<cshShowExplain>().IsOn = true;
                    IsOn = false;
                    this.audio.Stop();
                }
                else
                {
                    shakeTime -= Time.deltaTime;
                }
            }
        }
    }
}
