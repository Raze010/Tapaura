using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public partial class Competence {
    public Gameobject groupe, voile;

    public void UI() {
        groupe.Gameobject.SetActive(EstVisible() || EstDebloquer());
        voile.Gameobject.SetActive(!EstDebloquer());
    }
}
