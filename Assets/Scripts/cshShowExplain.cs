using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshShowExplain : MonoBehaviour
{
    private Text ExplainText;
    private string text;
    public Transform Explain;
    public Transform ExplainPos;

    public bool IsOn;

    public int phase;

    private Vector3 position;

    public bool flag;

    private float timer = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        IsOn = true;
        phase = 0;
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsOn)
        {
            position = new Vector3(ExplainPos.position.x, ExplainPos.position.y, ExplainPos.position.z + 1.0f);
            switch (phase)
            {
                case 0:
                    text = "지진에 대비하여 비상용품을 준비해봅시다.\n" +
                        "물, 통조림, 라면 등 가열하지 않고 먹을 수 있는 비상식품\n" +
                        "연고, 감기약, 소화제, 지병약 등이 포함된 구급약품\n" +
                        "간단한 옷, 화장지, 물티슈, 여성용품, 비닐봉지와 같은 생활용품\n" +
                        "그리고 라디오, 손전등 및 건전지, 비상금, 비상연락망 등을 준비합니다.";
                    showExplain();
                    break;
                case 1:
                    text = "사전에 준비한 비상용품은 대피 즉시 휴대할 수 있도록 출구 가까이에 둡니다.\n" +
                        "만약 어린 아이가 있다면 분유나 기저귀 등도 미리 준비합니다.";
                    showExplain();
                    this.GetComponent<cshWakeupPlayer>().IsOn = true;
                    break;
                case 2:
                    text = "잠시 뒤 지진이 시작됩니다.\n" +
                        "땅이 흔들리면 테이블 아래로 들어가세요!\n";
                    showExplain();
                    this.GetComponent<cshWakeupPlayer>().IsOn = true;
                    break;
                case 3:
                    IsOn = false;
                    this.GetComponent<cshShakePlayer>().ShakeAmount = 0.1f;
                    this.GetComponent<cshShakePlayer>().IsOn = true;
                    break;
                case 4:
                    if (timer <= 0.0f)
                    {
                        text = "지진으로 크게 흔들리는 시간은 길어야 1~2분 정도입니다.\n" +
                            "중심이 낮고 튼튼한 탁자의 아래로 들어가 탁자 다리를 꼭 잡고 몸을 보호합니다.\n" +
                            "탁자 아래와 같은 피할 곳이 없을 때에는 방석 등으로 머리를 보호합니다.\n" +
                            "흔들림이 멈추면 전기와 가스를 차단하고\n" +
                            "문을 열어 출구를 확보합니다.";
                        showExplain();
                        this.GetComponent<cshExitTable>().IsOn = true;
                    }
                    else
                    {
                        timer -= Time.deltaTime;
                    }
                    break;
                case 5:
                    text = "흔들림이 멈춘 후 당황하지 말고 화재에 대비하여 가스와 전깃불을 끕니다.\n" +
                        "가스밸브를 잠그고 누전차단기를 내리세요.";
                    this.GetComponent<cshExitTable>().IsOn = true;
                    showExplain();
                    break;
                case 6:
                    GameObject.Find("TubeValve").GetComponent<BoxCollider>().enabled = true;
                    GameObject.Find("FuseBoxDoor").GetComponent<BoxCollider>().enabled = true;
                    IsOn = false;
                    break;
                case 7:
                    text = "문이나 창문을 열어 언제든 대피할 수 있도록 출구를 확보합니다.\n" +
                        "문을 여세요.";
                    showExplain();
                    break;
                case 8:
                    text = "집에서 나갈 때는 발을 보호할 수 있는 신발을 신고 이동합니다.\n" +
                        "지진이 발생하면 유리 조각이나 떨어져 있는 물체 때문에 발을 다칠 수 있으니,\n" +
                        "발을 보호할 수 있는 신발을 신고 이동합니다.\n" +
                        "신발을 신으세요.";
                    showExplain();
                    break;
                case 9:
                    text = "계단을 이용하여 밖으로 대피합니다\n" +
                        "지진이 나면 엘리베이터를 타지 말고, 계단을 이용하여 건물 밖으로 대피합니다.\n" +
                        "밖으로 나갈 때에는 떨어지는 유리, 간판, 기와 등에 주의하며,\n" +
                        "소지품으로 몸을 보호하면서 침착하게 대피합니다.";
                    showExplain();
                    this.GetComponent<cshQuit>().IsOn = true;
                    break;
                case 10:
                    this.GetComponent<cshQuit>().IsOn = true;
                    break;
                case 11:
                    text = "대피 장소에서는 안내에 따라 질서를 지킵니다.\n" +
                        "지진 발생 직후에는 근거 없는 소문이나 유언비어가 유포될 수 있으니,\n" +
                        "라디오나 공공기관의 안내 방송 등이 제공하는 정보에 따라 행동합니다.";
                    showExplain();
                    this.GetComponent<cshQuit>().IsOn = true;
                    break;
                case 12:
                    text = "실내에서의 지진 대피 요령 안내가 끝났습니다.\n" +
                        "행정안전부의 <안전디딤돌> 어플리케이션을 설치하면\n" +
                        "더 많은 지진 및 재난 정보를 알 수 있습니다\n\n" +
                        "안내를 마칩니다.";
                    showExplain();
                    break;
            }
        }
    }

    void showExplain()
    {
        IsOn = false;
        Instantiate(Explain, position, ExplainPos.rotation);
        ExplainText = GameObject.Find("ExplainText").GetComponent<Text>();
        ExplainText.text = text;
    }
}
