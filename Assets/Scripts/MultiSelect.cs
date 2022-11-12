using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.FDG.InputManager
{
    public static class MultiSelect
    {
        private static Texture2D _whiteTexture;

        public static Texture2D WhiteTexture
        {
            get
            {
                if (_whiteTexture == null)
                {
                    _whiteTexture = new Texture2D(1,1);
                    _whiteTexture.SetPixel(0,0,Color.white);
                    _whiteTexture.Apply();


                }
                return _whiteTexture;
            }
        }

        public static void DrawScreenRect(Rect rect, Color color)
        {
            //Dibujo del Rectangulo de Seleccion de Personajes 
            GUI.color = color;
            GUI.DrawTexture(rect , WhiteTexture);


        }

        public static void DrawScreenRectBorder(Rect rect , float thickness , Color color)
        {
            // Arriba
            DrawScreenRect(new Rect(rect.xMin,rect.yMin,rect.width,thickness),color);
            //Abajo
            DrawScreenRect(new Rect(rect.xMin,rect.yMax - thickness,rect.width,thickness),color);
            //izquierda
            DrawScreenRect(new Rect(rect.xMin,rect.yMin,thickness,rect.height),color);
            //derecha
            DrawScreenRect(new Rect(rect.xMax - thickness, rect.yMin,thickness,rect.height),color);
        }

        public static Rect GetScreenRect(Vector3 screenPos1,Vector3 screenPos2)
        {
            //Dibujo del Rectangulo que ira desde abajo a la derecha hacia arriba a la izquierda
            screenPos1.y = Screen.height - screenPos1.y;
            screenPos2.y = Screen.height - screenPos2.y;

            //Esquinas 
            Vector3 bottomRight = Vector3.Max(screenPos1,screenPos2);
            Vector3 topLeft = Vector3.Min(screenPos1,screenPos2);

            // implementacion visual de Rectangulo

            return Rect.MinMaxRect(topLeft.x,topLeft.y,bottomRight.x,bottomRight.y);

        }

        public static Bounds GetVPBounds(Camera cam, Vector3 screenPos1, Vector3 screenPos2)
        {
            //usando la camara y tomando su Viewport como referencia para poder conocer los limites de la seleccion
            Vector3 pos1 = cam.ScreenToViewportPoint(screenPos1);
            Vector3 pos2 = cam.ScreenToViewportPoint(screenPos2);

            Vector3 min = Vector3.Min(pos1,pos2);
            Vector3 max = Vector3.Max(pos1,pos2);

            min.z = cam.nearClipPlane;
            max.z = cam.farClipPlane;

            Bounds bounds = new Bounds();
            bounds.SetMinMax(min,max);

            return bounds;


        }

    }
}
