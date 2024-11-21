using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionRoom : MonoBehaviour
{
    [SerializeField] private MoveLinear entryDoor;
    [SerializeField] private MoveLinear exitDoor;
    [SerializeField] private bool isEnterance;
    [SerializeField] private string nextLevelName;


    private void Start()
    {
        if(isEnterance) StartCoroutine(OpenExitDoor());
    }

    public void OpenEntryDoor()
    {
        entryDoor.Activate();
    }

    public void CloseEntryDoor()
    {
        entryDoor.ActivateReverse();
        StartCoroutine(DisplayLevelStats());
        StartCoroutine(ChangeLevel());
    }

    private IEnumerator DisplayLevelStats()
    {
        yield return new WaitForSeconds(4);
        StatsScreen.Instance.gameObject.SetActive(true);
    }

    private IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(nextLevelName);
    }

    private IEnumerator OpenExitDoor()
    {
        yield return new WaitForSeconds(2);
        exitDoor.Activate();
    }
}
