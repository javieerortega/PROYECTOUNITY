using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carta : MonoBehaviour
{

    public int id;
    public bool isRevealed = false;
    public Sprite image;
    public Sprite back;
    private Scenecontrol controller;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Scenecontrol>();
    }

    void OnMouseDown()
    {
        if (isRevealed || !controller.canReveal) return;
        GetComponent<SpriteRenderer>().sprite = image;
        isRevealed = true;
        controller.CardRevealed(this);
    }

    public void Unreveal()
    {
        GetComponent<SpriteRenderer>().sprite = back;
        isRevealed = false;
    }

    public void ChangeSprite(int id, Sprite image)
    {
        this.id = id;
        this.image = image;
    }
}