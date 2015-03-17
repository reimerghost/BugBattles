using UnityEngine;
using System.Collections;

public class escalarGUI
{

    public static int optimalHeight = 854;
    public static int optimalWidth = 480;

    //Metodo para escalar la pantalla a diferentes tipos de pantallas.
    public static Rect ResizeGUI(Rect _rect)
    {

        //Nuevo Ancho
        float FilScreenWidth = _rect.width / optimalHeight;
        float rectWidth = FilScreenWidth * Screen.width;

        //Nuevo Alto
        float FilScreenHeight = _rect.height / optimalWidth;
        float rectHeight = FilScreenHeight * Screen.height;

        //Nueva posición
        float rectX = getPosX(_rect.x);
        float rectY = getPosY(_rect.y);

        return new Rect(rectX, rectY, rectWidth, rectHeight);
    }

    public static float getPosX(float x)
    {
        return (x / optimalWidth) * Screen.width;
    }

    public static float getPosY(float y)
    {
        return ((y / optimalHeight) * Screen.height);
    }
}