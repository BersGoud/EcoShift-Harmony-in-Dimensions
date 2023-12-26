using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainPage;
    public GameObject levelSelectPage;
    public GameObject creditSelectPage;

    void Start()
    {
        // Bij het starten van de applicatie zijn Level en Credit verborgen en niet actief
        mainPage.SetActive(true);
        levelSelectPage.SetActive(false);
        creditSelectPage.SetActive(false);

        // Voer ShowLevelSelectPage uit als de knop "ButtonLevels" is ingedrukt in de "Main page"
        Button buttonLevels = mainPage.transform.Find("ButtonLevels").GetComponent<Button>();
        if (buttonLevels != null)
        {
            buttonLevels.onClick.AddListener(ShowLevelSelectPage);
        }

        // Voer ShowCreditSelectPage uit als de knop "ButtonCredits" is ingedrukt in de "Main page"
        Button buttonCredit = mainPage.transform.Find("ButtonCredits").GetComponent<Button>();
        if (buttonCredit != null)
        {
            buttonCredit.onClick.AddListener(ShowCreditSelectPage);
        }

        // Voer ExitApplication uit als de knop "ButtonExit" is ingedrukt in de "Main page"
        Button buttonExit = mainPage.transform.Find("ButtonExit").GetComponent<Button>();
        if (buttonExit != null)
        {
            buttonExit.onClick.AddListener(Quit);
        }


        // Voer CloseCurrentPage uit als de knop "ButtonClose" is ingedrukt in de "Level select page"
        Button close2 = levelSelectPage.transform.Find("ButtonClose").GetComponent<Button>();
        if (close2 != null)
        {
            close2.onClick.AddListener(CloseCurrentPage);
        }

        // Voer CloseCurrentPage uit als de knop "ButtonClose" is ingedrukt in de "Credit select page"
        Button close3 = creditSelectPage.transform.Find("ButtonClose").GetComponent<Button>();
        if (close3 != null)
        {
            close3.onClick.AddListener(CloseCurrentPage);
        }
    }

    public void ShowLevelSelectPage()
    {
        // Toon Level select en maak het actief
        mainPage.SetActive(false);
        levelSelectPage.SetActive(true);
        creditSelectPage.SetActive(false);
    }

    public void CloseCurrentPage()
    {
        // Sluit de huidige pagina en maak de eerste pagina actief
        mainPage.SetActive(true);
        levelSelectPage.SetActive(false);
        creditSelectPage.SetActive(false);
    }

    public void ShowCreditSelectPage()
    {
        // Toon Credit select en maak het actief
        mainPage.SetActive(false);
        levelSelectPage.SetActive(false);
        creditSelectPage.SetActive(true);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

