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
        float rectWidth = getAlto(_rect.width);

        //Nuevo Alto
        float rectHeight = getAncho(_rect.height);

        //Nueva posición
        float rectX = getPosX(_rect.x);
        float rectY = getPosY(_rect.y);

        return new Rect(rectX, rectY, rectWidth, rectHeight);
    }

    //POSICIONES
    public static float getPosX(float x)
    {
        return (x / optimalWidth) * Screen.width;
    }

    public static float getPosY(float y)
    {
        return ((y / optimalHeight) * Screen.height);
    }

    //TAMAÑOS
    public static float getAncho(float w)
    {
        float FilScreenWidth = w / optimalHeight;
        return (FilScreenWidth * Screen.width);
    }

    public static float getAlto(float h)
    {
        float FilScreenHeight = h / optimalWidth;
        return (FilScreenHeight * Screen.height);
    }
}