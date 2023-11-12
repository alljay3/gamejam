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
    [SerializeField] public GameObject AnswerUI;
    [SerializeField] private Player GPlayer;
    [HideInInspector] public bool PlayerStay = false;
    [HideInInspector] public bool DialogReady = false;
    [SerializeField] public List<int> StepDialog = new List<int>();
    [SerializeField] private float SpeedDialog = 1;
    [SerializeField] public AudioSource music;
    [SerializeField] private AudioClip [] AudioClips;
    [SerializeField] private GameObject[] OtherObjects;
    [SerializeField] private string StartAnim;

    private void Start()
    {
        if (StartAnim != null)
        {
            GetComponent<Animator>().Play(StartAnim);
        }
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
            case 2:
                StartCoroutine(Step2());
                break;
            case 3:
                StartCoroutine(Step3());
                break;
            case 4:
                StartCoroutine(Step4());
                break;
            case 100:
                StartCoroutine(Step100());
                break;
            case 150:
                StartCoroutine(Step150());
                break;
            case 200:
                StartCoroutine(Step200());
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
        DialogUINPCPanel.transform.position = new Vector2(transform.position.x, transform.position.y + 3.1f);
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

    public void PlayHold()
    {
        gameObject.GetComponent<Animator>().Play("Hold");
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(10);
        Application.Quit();
    }


    IEnumerator Step0()
    {
        GPlayer.inputOn = false;
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Animator>().Play("Hold");
        GPlayer.GetComponent<Animator>().Play("Hold");
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
        GPlayer.GetComponent<Animator>().Play("Hold");
        gameObject.GetComponent<Animator>().Play("Hold");
        yield return StartCoroutine(DialogPlayer(DilogList1.player[MainScript.language, 2], 2 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DilogList1.friend[MainScript.language, 0], 2 * SpeedDialog));
        OtherObjects[0].GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<Animator>().Play("Drug");
        yield return StartCoroutine(DialogPlayer(DilogList1.player[MainScript.language, 3], 2 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DilogList1.friend[MainScript.language, 1], 2 * SpeedDialog));
        music.clip = AudioClips[0];
        music.Play();
        music.loop = false;
        yield return StartCoroutine(UpCamera());
        yield return new  WaitForSeconds(3);
        SceneManager.LoadScene("Level2");
        GPlayer.inputOn = true;
    }
    IEnumerator Step2()
    {
        GPlayer.inputOn = false;
        GPlayer.GetComponent<Animator>().Play("Hold");
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Animator>().Play("Hold");
        yield return StartCoroutine(DialogNPC(DialogList2.mother[MainScript.language, 0], 2 * SpeedDialog));
        yield return StartCoroutine(DialogPlayer(DialogList2.player[MainScript.language, 0], 2 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DialogList2.mother[MainScript.language, 1], 2 * SpeedDialog));
        yield return StartCoroutine(DialogPlayer(DialogList2.player[MainScript.language, 1], 2 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DialogList2.mother[MainScript.language, 2], 2 * SpeedDialog));
        yield return StartCoroutine(DialogPlayer(DialogList2.player[MainScript.language, 2], 2 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DialogList2.mother[MainScript.language, 3], 2 * SpeedDialog));
        yield return StartCoroutine(DialogPlayer(DialogList2.player[MainScript.language, 3], 2 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DialogList2.mother[MainScript.language, 4], 2 * SpeedDialog));
        yield return StartCoroutine(DialogPlayer(DialogList2.player[MainScript.language, 4], 2 * SpeedDialog));
        gameObject.GetComponent<AudioSource>().clip = AudioClips[0];
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Animator>().Play("Kashel");
        OtherObjects[0].SetActive(true);
        GPlayer.inputOn = true;
    }
    IEnumerator Step3()
    {
        GPlayer.inputOn = false;
        GPlayer.GetComponent<Animator>().Play("Hold");
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Animator>().Play("Hold");
        yield return StartCoroutine(DialogPlayer(DialogList3.player[MainScript.language, 0], 3 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DialogList3.friend[MainScript.language, 0], 3 * SpeedDialog));
        yield return StartCoroutine(DialogPlayer(DialogList3.player[MainScript.language, 1], 3 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DialogList3.friend[MainScript.language, 1], 3 * SpeedDialog));
        yield return StartCoroutine(DialogPlayer(DialogList3.player[MainScript.language, 2], 3 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DialogList3.friend[MainScript.language, 2], 3 * SpeedDialog));
        yield return StartCoroutine(DialogPlayer(DialogList3.player[MainScript.language, 3], 3 * SpeedDialog));
        GPlayer.inputOn = true;
        OtherObjects[0].SetActive(true);
    }

    IEnumerator Step4()
    {
        GPlayer.inputOn = false;
        GPlayer.GetComponent<Animator>().Play("Hold");
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().loop = false;
        yield return StartCoroutine(DialogPlayer(DialogList4.player[MainScript.language, 0], 3 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DialogList4.mother[MainScript.language, 0], 2 * SpeedDialog));
        yield return StartCoroutine(DialogPlayer(DialogList4.player[MainScript.language, 1], 3 * SpeedDialog));


        gameObject.GetComponent<Animator>().Play("Ger_output");
        OtherObjects[1].SetActive(true);

        yield return StartCoroutine(DialogNPC(DialogList4.mother[MainScript.language, 1], 3 * SpeedDialog));
        yield return StartCoroutine(DialogPlayer(DialogList4.player[MainScript.language, 2], 3 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DialogList4.mother[MainScript.language, 2], 4 * SpeedDialog));
        yield return StartCoroutine(DialogPlayer(DialogList4.player[MainScript.language, 3], 4 * SpeedDialog));
        yield return StartCoroutine(DialogNPC(DialogList4.mother[MainScript.language, 3], 2 * SpeedDialog));

        OtherObjects[1].SetActive(false);

        gameObject.GetComponent<AudioSource>().clip = AudioClips[0];
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Animator>().Play("Kashel");
        OtherObjects[0].SetActive(true);
        GPlayer.inputOn = true;
    }

    IEnumerator Step100()
    {
        GPlayer.inputOn = false;
        GPlayer.GetComponent<Animator>().Play("Plach");
        yield return StartCoroutine(DialogPlayer(DialogList5.player[MainScript.language, 0], 2 * SpeedDialog));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DialogPlayer(DialogList5.player[MainScript.language, 1], 2 * SpeedDialog));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DialogPlayer(DialogList5.player[MainScript.language, 2], 2 * SpeedDialog));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DialogPlayer(DialogList5.player[MainScript.language, 3], 2 * SpeedDialog));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DialogPlayer(DialogList5.player[MainScript.language, 4], 2 * SpeedDialog));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DialogPlayer(DialogList5.player[MainScript.language, 5], 2 * SpeedDialog));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DialogPlayer(DialogList5.player[MainScript.language, 6], 2 * SpeedDialog));
        yield return new WaitForSeconds(1);
        OtherObjects[0].SetActive(true);
        GPlayer.inputOn = true;
    }
    IEnumerator Step150()
    {
        if (gameObject.tag == "Mother")
        {
            GPlayer.inputOn = false;
            GPlayer.GetComponent<Animator>().Play("Hold");
            OtherObjects[1].GetComponent<FinalyBox>().IsReady = false;
            OtherObjects[2].SetActive(false);
            GPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("Hold");
            GPlayer.GetComponent<Animator>().Play("Hold");
            yield return StartCoroutine(DialogPlayer(DialogList6.player[MainScript.language, 0], 2 * SpeedDialog));
            yield return StartCoroutine(DialogNPC(DialogList6.mother[MainScript.language, 0], 2 * SpeedDialog));
            yield return StartCoroutine(DialogPlayer(DialogList6.player[MainScript.language, 1], 2 * SpeedDialog));
            yield return StartCoroutine(DialogNPC(DialogList6.mother[MainScript.language, 1], 2 * SpeedDialog));
            yield return StartCoroutine(DialogPlayer(DialogList6.player[MainScript.language, 2], 2 * SpeedDialog));
            OtherObjects[0].SetActive(true);
            
            GPlayer.inputOn = true;
        }
        else
        {
            GPlayer.inputOn = false;
            GPlayer.GetComponent<Animator>().Play("Hold");
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("Hold");
            yield return StartCoroutine(DialogPlayer(DialogList6.player[MainScript.language, 3], 3 * SpeedDialog));
            yield return StartCoroutine(DialogNPC(DialogList6.friend[MainScript.language, 0], 3 * SpeedDialog));
            yield return StartCoroutine(DialogPlayer(DialogList6.player[MainScript.language, 4], 3 * SpeedDialog));
            yield return StartCoroutine(DialogNPC(DialogList6.friend[MainScript.language, 1], 3 * SpeedDialog));
            OtherObjects[0].SetActive(true);
            GPlayer.inputOn = true;
        }
    }

    IEnumerator Step200()
    {
        GPlayer.inputOn = false;
        GPlayer.GetComponent<Animator>().Play("Hold");
        yield return StartCoroutine(DialogPlayer(DialogListWin.player[MainScript.language, 0], 2 * SpeedDialog));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DialogPlayer(DialogListWin.player[MainScript.language, 1], 2 * SpeedDialog));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DialogPlayer(DialogListWin.player[MainScript.language, 2], 2 * SpeedDialog));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DialogPlayer(DialogListWin.player[MainScript.language, 3], 2 * SpeedDialog));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DialogPlayer(DialogListWin.player[MainScript.language, 4], 4 * SpeedDialog));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DialogPlayer(DialogListWin.player[MainScript.language, 5], 4 * SpeedDialog));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DialogPlayer(DialogListWin.player[MainScript.language, 6], 2 * SpeedDialog));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DialogPlayer(DialogListWin.player[MainScript.language, 7], 2 * SpeedDialog));
        GPlayer.inputOn = true;
        yield return StartCoroutine(Exit());
    }
}
