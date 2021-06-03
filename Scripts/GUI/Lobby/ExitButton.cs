using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{


    public Sprite ActiveButton;
    private Image _image;
    private Sprite BeforeSprite;
    // Start is called before the first frame update
    void Start()
    {
        _image = gameObject.GetComponent<Image>();
        BeforeSprite = _image.sprite;
    }

    void OnMouseEnter()
    {
        _image.sprite = ActiveButton;
    }

    void OnMouseExit()
    {
        _image.sprite = BeforeSprite;
    }

    void OnMouseDown()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
