using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Animate_Megaphone : MonoBehaviour
{

    RectTransform MovingText;  //Declare RectTransform in script
    Vector3 startingPos = new Vector3(-1078, -6.3f, 0);
    Vector3 endPos = new Vector3(1173, -6.3f, 0); //La nueva posición del texto.

    private int Estado;
    //Estados del texto en movimiento.
    private const int Parado = 0;
    private const int Moviendose = 1;

    void Start()
    {
        Estado = Parado;
        MovingText = GetComponent<RectTransform>();
    }



    void Update()
    {
        if (Estado == Parado)
        {
            Estado = Moviendose;
            //MovingText.localPosition = Vector3.SmoothDamp(MovingText.localPosition, endPos, ref buttonVelocity, smoothTime);
            MovingText.localPosition = Vector3.MoveTowards(MovingText.localPosition, endPos, 1.00f);
        }
        if (Estado == Moviendose)
        {
            if (MovingText.localPosition.x >= endPos.x)
            {
                MovingText.localPosition = startingPos;
                Estado = Parado;
            }
            else
            {
                MovingText.localPosition = Vector3.MoveTowards(MovingText.localPosition, endPos, 1.00f);
            }
        }
    }
}