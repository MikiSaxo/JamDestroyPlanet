using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Febucci.UI;
using UnityEngine.SceneManagement;

public class AnimUI : MonoBehaviour
{
    [SerializeField] private GameObject[] _UIParents;
    [SerializeField] private GameObject[] _mainButtons;
    [SerializeField] private GameObject[] _creditsAssets;
    [SerializeField] private float _timeEachSpawn;
    [SerializeField] private float _timeShrink;

    [SerializeField] private float _scaleHoverButtons;
    [SerializeField] private float _timeHoverButtonsOn;
    [SerializeField] private float _timeHoverButtonsOff;
    [SerializeField] private Color _idleColor;
    [SerializeField] private Color _idleColorAlpha;
    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _selectedColorAlpha;

    private bool isLaunched = false;

    private void Start()
    {
        StartCoroutine(SpawnMainMenu(_mainButtons));
    }
    private IEnumerator SpawnMainMenu(GameObject[] _buttons)
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            yield return new WaitForSeconds(_timeEachSpawn);
            _buttons[i].transform.DOScale(Vector3.one * 1.2f, 0);
            _buttons[i].transform.DOScale(Vector3.one, _timeShrink);
            yield return new WaitForSeconds(_timeEachSpawn);
        }
    }

    public void LaunchCredits()
    {
        if (isLaunched)
            return;

        StartCoroutine(MoveToCredits());
        isLaunched = true;
    }

    IEnumerator MoveToCredits()
    {
        Transi2.Instance.TransiOn();
        yield return new WaitForSeconds(Transi2.Instance.TimeTransiOn);

        for (int i = 0; i < _mainButtons.Length; i++)
        {
            _mainButtons[i].transform.localScale = Vector3.zero;
        }

        _UIParents[0].SetActive(false);
        _UIParents[1].SetActive(true);
        StartCoroutine(SpawnMainMenu(_creditsAssets));
        Transi2.Instance.TransiOff();
        isLaunched = false;
    }

    public void LaunchMain()
    {
        if (isLaunched)
            return;
        StartCoroutine(MoveToMain());
        isLaunched = true;
    }

    IEnumerator MoveToMain()
    {
        Transi2.Instance.TransiOn();
        yield return new WaitForSeconds(Transi2.Instance.TimeTransiOn);

        for (int i = 0; i < _creditsAssets.Length; i++)
        {
            _creditsAssets[i].transform.localScale = Vector3.zero;
        }

        _UIParents[0].SetActive(true);
        _UIParents[1].SetActive(false);
        StartCoroutine(SpawnMainMenu(_mainButtons));
        Transi2.Instance.TransiOff();
        isLaunched = false;
    }


    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
              UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void StartGame()
    {
        print("�a lance le jeu ici");
    }

    public void PointerEnterButtons(GameObject _himself)
    {
        _himself.transform.DOScale(Vector3.one * _scaleHoverButtons, _timeHoverButtonsOn);
        _himself.GetComponent<ButtonsNames>().parts[1].GetComponent<TextMeshProUGUI>().color = _selectedColor;
        //_himself.GetComponent<ButtonsNames>().parts[0].GetComponent<TextMeshProUGUI>().color = _idleColorAlpha;
    }

    public void PointerExitButtons(GameObject _himself)
    {
        _himself.transform.DOScale(Vector3.one, _timeHoverButtonsOff);
        //_himself.GetComponent<ButtonsNames>().parts[0].GetComponent<TextMeshProUGUI>().color = _selectedColorAlpha;
        _himself.GetComponent<ButtonsNames>().parts[1].GetComponent<TextMeshProUGUI>().color = _selectedColorAlpha;
    }

    public void PointerClick(GameObject _himself)
    {
        _himself.transform.localScale = Vector3.one * .8f;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
