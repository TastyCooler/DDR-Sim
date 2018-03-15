﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue  { //Dialogue Class, as a "Tool" to create text

    #region Public functions
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;
    #endregion 
}
