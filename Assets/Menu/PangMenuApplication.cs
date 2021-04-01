using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangMenuApplication : MonoBehaviour
{
    public PangMenuModel Model;
    public PangMenuView View;
    public PangMenuController Controller;
}

public class PangMenuElement : MonoBehaviour
{
    public PangMenuApplication App { get { return FindObjectOfType<PangMenuApplication>(); } }
}
