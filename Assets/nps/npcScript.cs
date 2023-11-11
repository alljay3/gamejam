using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class npcScript : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private MainScript MScript;
    [SerializeField] private GameObject DialogUINPCPanel;
    [SerializeField] private GameObject DialogUIPLAYERPanel;
    [SerializeField] private TMPro.TextMeshProUGUI DialogUINPC;
    [SerializeField] private TMPro.TextMeshProUGUI DialogUIPLAYER;
    [SerializeField] private GameObject AnswerUI;
    [SerializeField] private Player GPlayer;
    [HideInInspector] public bool PlayerStay = false;
    [HideInInspector] public bool DialogReady = false;
    [SerializeField] public List<int> StepDialog = new List<int>();
    [SerializeField] private float SpeedDialog = 1;
    [SerializeField] public AudioSource music;
    [SerializeField] private AudioClip [] AudioClips;
    [SerializeField] private GameObject[] OtherObjects;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStay == true && StepDialog.Contains(MainScript.step))
        {
            AnswerUI.SetActive(true);
            if (Input.GetButtonDown("Submit"))
            {
                Debug.Log("KEKE");
                Dialog();
                MainScript.step += 1;
                Debug.Log(MainScript.step);
                AnswerUI.SetActive(false);
                GPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
    void Dialog()
    {
        switch (MainScript.step)
        {
            case 0:
                StartCoroutine(Step0());
                break;
            case 1:
                StartCoroutine(Step1());
                break;
            default:
                break;
        }
    }
    IEnumerator DialogPlayer(string text, float time)
    {
        DialogUIPLAYERPanel.SetActive(true);
        DialogUIPLAYER.text = text;
        yield return new WaitForSeconds(time);
        DialogUIPLAYERPanel.SetActive(false);
    }
    IEnumerator DialogNPC(string text, float time)
    {
        DialogUINPCPanel.SetActive(true);
        DialogUINPCPanel.transform.position = transform.position;
        DialogUINPCPanel.transform.position = new Vector2(transform.position.x, transform.position.y + 3.3f);
        DialogUINPC.text = text;
        yield return new WaitForSeconds(time);
        DialogUINPCPanel.SetActive(false);
    }

    IEnumerator UpCamera()
    {
        int count = 0;
        while(count < 600)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + 0.02f, mainCamera.transform.position.z);
            yield return new WaitForSeconds(0.01f);
            count += 1;
        }
    }

    IEnumerator Step0()
    {
        GPlayer.inputOn = false;
        gameObject.GetComponent<AudioSource>().Play();
        yield return StartCoroutine(DialogPlayer(DilogList1.player[MainScript.language, 0], 2 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DilogList1.mother[MainScript.language, 0], 2 * SpeedDialog));
        yield return StartCoroutine(DialogPlayer(DilogList1.player[MainScript.language, 1], 2 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DilogList1.mother[MainScript.language, 1], 2 * SpeedDialog));
        GPlayer.inputOn = true;
        MScript.DoorOpen();
        OtherObjects[0].GetComponent<AudioSource>().Play();
    }

    IEnumerator Step1()
    {
        GPlayer.inputOn = false;
        gameObject.GetComponent<AudioSource>().Play();
        yield return StartCoroutine(DialogPlayer(DilogList1.player[MainScript.language, 2], 2 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DilogList1.friend[MainScript.language, 0], 2 * SpeedDialog));
        yield return StartCoroutine(DialogPlayer(DilogList1.player[MainScript.language, 3], 2 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DilogList1.friend[MainScript.language, 1], 2 * SpeedDialog));
        music.clip = AudioClips[0];
        music.Play();
        music.loop = false;
        yield return StartCoroutine(UpCamera());
        GPlayer.inputOn = true;
    }
}
