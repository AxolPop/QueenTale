using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class submitReport : MonoBehaviour
{

    public GameObject dropdownOne;
    public TMP_Dropdown dropOne;
    public GameObject shortDesc;
    public TMP_InputField inputOne;
    public GameObject longDesc;
    public TMP_InputField inputTwo;
    public GameObject dropdownTwo;
    public TMP_Dropdown dropTwo;
    public string cpu;
    public string gpu;
    public string provider;

    public string googleForm = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfHF8xTzqn47C5oRtVB_KV0p8wtgPyOX2IpaLO0ewZyAtf5zA/formResponse";

    // Start is called before the first frame update
    void Start()
    {
        dropOne = dropdownOne.GetComponent<TMP_Dropdown>();
        dropTwo = dropdownTwo.GetComponent<TMP_Dropdown>();

        inputOne = shortDesc.GetComponent<TMP_InputField>();
        inputTwo = longDesc.GetComponent<TMP_InputField>();

        cpu = SystemInfo.processorType;
        gpu = SystemInfo.graphicsDeviceName;
        provider = SystemInfo.graphicsDeviceVendor;
    }

    public void SendForm()
    {
        StartCoroutine(FormDetails(dropOne.value.ToString(), inputOne.text, inputTwo.text, dropTwo.value.ToString(), cpu, gpu, provider));
    }

    IEnumerator FormDetails (string q1, string q2, string q3, string q4, string cpu, string gpu, string provider)
    {
        WWWForm form = new WWWForm();

        form.AddField("entry.1731039200", q1);

        form.AddField("entry.1531781918", q2);

        form.AddField("entry.1014911996", q3);

        form.AddField("entry.1908912262", q4);

        form.AddField("entry.1890875293", cpu);

        form.AddField("entry.1823703201", gpu);

        form.AddField("entry.1621983121", provider);

        UnityWebRequest www = UnityWebRequest.Post(googleForm, form);

        yield return www.SendWebRequest();
    }
}
