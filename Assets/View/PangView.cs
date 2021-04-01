using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PangView : PangElement
{
    public MenuView Menu;
    public PlayerView Player;
    public KeyboardInputView Input;

    public Transform BallContainer;
    public Transform VineContainer;

    public EnterNameView EnterName;

    public DiedScreenView DiedScreen;

    public InfoView Info;
}
