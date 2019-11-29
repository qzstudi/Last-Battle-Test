using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private void Init()
    {
        Facade.Instance.AddManager<ObjManager>("ObjManager");
        Facade.Instance.AddManager<ResourceManager>("ResourceManager");
    }
    // Use this for initialization
    void Start()
    {
        Init();
        ObjManager ObjMgr = Facade.Instance.GetManager<ObjManager>("ObjManager");
        GameObject obj = ObjMgr.CreateAndLoadObj("frontpanel", "frontpanel");
        ObjMgr.SetPanel(obj);
    }
    // Update is called once per frame
        void Update () {
		
	}
}
