using UnityEngine;
using UnityEngine.Events;
public class GameStageManager : MonoBehaviour
{
    public enum GameStage
    {
        RadioTurnOn1,
        TalkingWithMainNPC1,
        RadioAndFog,
        TalkingWithMainNPC2,
        GoToPostOffice
        // 다음 단계는 여기에
    }

    public GameStage currentStage = GameStage.RadioTurnOn1;
    public UnityEvent radioClicked1;
    public UnityEvent mainNPCClicked1;
    public UnityEvent radioClicked2;
    public UnityEvent mainNPCClicked2;
    public UnityEvent mainNPCClicked3;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                GameObject clicked = hit.collider.gameObject;
                Debug.Log("? 클릭한 오브젝트: " + clicked.tag);

                // 조건: GameStage가 None이고, 클릭된 태그가 Radio인 경우
                if (currentStage == GameStage.RadioTurnOn1 && clicked.CompareTag("Radio"))
                {
                    radioClicked1.Invoke();
                }
                else if(currentStage == GameStage.TalkingWithMainNPC1 && clicked.CompareTag("MainNPC"))
                {
                    mainNPCClicked1.Invoke();
                }
                else if (currentStage == GameStage.RadioAndFog && clicked.CompareTag("Radio"))
                {
                    radioClicked2.Invoke();
                }
                else if(currentStage == GameStage.TalkingWithMainNPC2 && clicked.CompareTag("MainNPC"))
                {
                    mainNPCClicked2.Invoke();
                }
                else if(currentStage == GameStage.GoToPostOffice && clicked.CompareTag("MainNPC"))
                {
                    mainNPCClicked3.Invoke();
                }
                else
                {

                }
            }
        }
    }
}
