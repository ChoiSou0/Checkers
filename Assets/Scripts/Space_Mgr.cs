using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum CheckerState
{
    black, white
}

public enum SpaceState
{
    none, black, white
}

public class Space_Mgr : MonoBehaviour
{
    RaycastHit hit;

    public List<Space> spaceList = new List<Space>();
    public List<Vector3> Vec = new List<Vector3>();
    public List<Checker> checkersList = new List<Checker>();
    public List<Checker> SelectList = new List<Checker>();

    public int Black_Checker_Cnt;
    public int White_Checker_Cnt;

    public int Act;

    // Start is called before the first frame update
    void Start()
    {
        CheckCnt();
    }

    // Update is called once per frame
    void Update()
    {
        Click();
    }

    private void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int result = 0;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject Obj = hit.collider.gameObject;

                if (Obj.CompareTag("Checker"))
                {
                    if (SelectList.Count == 1)
                    {
                        if (SelectList[0].name == Obj.name)
                        {
                            SelectList.Clear();
                            return;
                        }
                        else if (SelectList[0].name != Obj.name)
                        {
                            SelectList.Clear();
                            SelectList.Add(Obj.GetComponent<Checker>());
                        }

                        return;
                    }

                    SelectList.Add(Obj.GetComponent<Checker>());
                }
                else if (Obj.CompareTag("Board"))
                {
                    if (SelectList.Count == 1 && 
                        Obj.GetComponent<Space>().spaceState == SpaceState.none)

                    {
                        result = SelectList[0].Num - Obj.GetComponent<Space>().Num;

                        if (result == 9 || result == 11 || result == -9 || result == -11)
                            ChangeChecker(SelectList[0], Obj.GetComponent<Space>());
                        else if (result == 18 || result == 22 || result == -18 || result == -22)
                            DestroyCheck(Obj.GetComponent<Space>(), result);

                    }

                }

            }

        }

    }

    private void DestroyCheck(Space space, int idx)
    {
        int i = SelectList[0].Num - idx - 1;
        if (spaceList[i].spaceState == SpaceState.none)
        {
            for (int j = 0; j < checkersList.Count; j++)
            {
                if (checkersList[j].Num == spaceList[SelectList[0].Num - idx / 2 - 1].Num)
                {
                    if (checkersList[j].checkerState == SelectList[0].checkerState)
                        return;

                    spaceList[checkersList[j].Num - 1].spaceState = SpaceState.none;
                    Destroy(checkersList[j].gameObject);
                    checkersList.Remove(checkersList[j]);
                    ChangeChecker(SelectList[0], space);
                    return;
                }
            }


        }
    }

    private void ChangeChecker(Checker checker, Space space)
    {
        if (checker.checkerState == CheckerState.black)
            space.spaceState = SpaceState.black;
        else if (checker.checkerState == CheckerState.white)
            space.spaceState = SpaceState.white;

        spaceList[checker.Num - 1].spaceState = SpaceState.none;
        checker.Num = space.Num;
        checker.transform.position = Vec[space.Num - 1];

        if (checker.checkerState == CheckerState.white && checker.Num <= 10)
            checker.TheKing = true;
        else if (checker.checkerState == CheckerState.black && checker.Num >= 91)
            checker.TheKing = true;

        SelectList.Clear();
        CheckCnt();
    }

    private void CheckCnt()
    {
        White_Checker_Cnt = 0;
        Black_Checker_Cnt = 0;

        for (int i = 0; i < checkersList.Count; i++)
        {
            if (checkersList[i].checkerState == CheckerState.white &&
                White_Checker_Cnt < 20)
                White_Checker_Cnt++;
            else if (checkersList[i].checkerState == CheckerState.black &&
                Black_Checker_Cnt < 20)
                Black_Checker_Cnt++;
        }
    }

    private void StartSetting()
    {

    }
}
