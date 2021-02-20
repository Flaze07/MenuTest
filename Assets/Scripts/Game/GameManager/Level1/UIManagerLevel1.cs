using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerLevel1 : MonoBehaviour {
    public void DeathYesBtnClick() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void DeathNoBtnClick() {
        SceneManager.LoadScene("Menu");
    }
}
