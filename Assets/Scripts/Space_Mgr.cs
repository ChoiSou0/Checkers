using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<Checker> SelectList = new List<Checker>();

    // Start is called before the first frame update
    void Start()
    {
        
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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject Obj = hit.collider.gameObject;

                if (Obj.CompareTag("Checker"))
                {
                    if (SelectList.Count == 1)
                        return;

                    SelectList.Add(Obj.GetComponent<Checker>());
                }
                else if (Obj.CompareTag("Board"))
                {

                }
            }
        }
    }

    private void StartSetting()
    {

    }
}
