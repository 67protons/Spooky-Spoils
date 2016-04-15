using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

    public string Scene1;
    public string Scene2;

    public void OtherLevel()
    {
        if (Application.loadedLevelName == Scene1)
            Application.LoadLevel(Scene2);
        else
            Application.LoadLevel(Scene1);
    }


}
