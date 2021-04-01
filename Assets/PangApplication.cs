using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangApplication : MonoBehaviour
{
    public PangModel Model;
    public PangView View;
    public PangController Controller;
}

public class PangElement : MonoBehaviour
{
    public PangApplication App { get { return FindObjectOfType<PangApplication>(); } }
}
