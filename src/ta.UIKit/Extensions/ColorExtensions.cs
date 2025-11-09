using System.Drawing;

namespace ta.UIKit;

public static class ColorExtensions
{
    public static Color ToSystemDrawingColor(this UnityEngine.Color unityColor)
    {
        return Color.FromArgb((int)(unityColor.a * 255),
            (int)(unityColor.r * 255),
            (int)(unityColor.g * 255),
            (int)(unityColor.b * 255));
    }

    public static UnityEngine.Color ToUnityColor(this Color systemDrawingColor)
    {
        return new UnityEngine.Color(systemDrawingColor.R / 255f,
            systemDrawingColor.G / 255f,
            systemDrawingColor.B / 255f,
            systemDrawingColor.A / 255f);
    }
}
