using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    Transform mainCam;
    Transform unit;
    Transform worldSpaceCanvas;

    public Vector3 offset;
    public TextMeshProUGUI levelText;

    public PlayerLevel playerLevel;
    [SerializeField] GameObject player;

    void Start()
    {
        mainCam = Camera.main.transform;
        unit = transform.parent;
        worldSpaceCanvas = GameObject.FindObjectOfType<Canvas>().transform;
        
        playerLevel = player.GetComponent<PlayerLevel>();

        levelText.text = "lv. " + playerLevel.playerLevelNumber.ToString();
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position);
        transform.position = unit.position + offset;
        levelText.text = "lv. " + playerLevel.playerLevelNumber.ToString();
    }

}
