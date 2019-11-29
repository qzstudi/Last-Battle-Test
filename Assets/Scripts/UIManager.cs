using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClickMidPanel()
    {
        ObjManager objMgr = Facade.Instance.GetManager<ObjManager>("ObjManager");
        GameObject panel = objMgr.GetPanel("frontpanel");
        panel.SetActive(false);

        GameObject midpanel = objMgr.GetPanel("midpanel");
        if (midpanel == null)
        {
            midpanel = objMgr.CreateAndLoadObj("midpanel", "midpanel");           
        }
        objMgr.SetPanel(midpanel);
        if (midpanel.activeSelf==false)
        {
            midpanel.SetActive(true);
        }
    }

    public void OnBackFrontPanel()
    {
        ObjManager objMgr = Facade.Instance.GetManager<ObjManager>("ObjManager");
        GameObject midpanel = objMgr.GetPanel("midpanel");
        midpanel.SetActive(false);
        GameObject panel = objMgr.GetPanel("frontpanel");
        panel.SetActive(true);
    }
}
