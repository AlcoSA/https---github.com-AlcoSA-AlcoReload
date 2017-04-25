
namespace DXF.Importador_DXF
{
    public enum Polyline_flag
    {
        default_ =0,
        closed=1,
        Curve_Fit = 2,
        Spline_Fit=4,
        Polyline_3D = 8,
        Polygon_Mesh_3D = 16,
        Polygon_Mesh_Closd = 32,
        Polyface_Mesh = 64,
        Plinegen = 128
    }

    public enum Spline_flag
    {
        default_ = 0,
        ClosedSpline=1,
        PeriodicSpline=2,
        RationalSpline = 4,
        Planar = 8,
        Linear= 16
    }

    public enum Text_Generation_Flag
    {
        default_ = 0,
        backward =2,
        upsideDown = 4
    }
    public enum Alingment
    {
        left =0,
        center = 1,
        right = 2,
        aligned = 3,
        middle = 4,
        fit=5
    }
    public enum AttachPoint
    {        
        TopLeft=1,
        TopCenter = 2,
        TopRight =3,
        MiddleLeft = 4,
        MiddleCenter =5,
        MiddleRight = 6,
        BottomLeft = 7,
        BottomCenter = 8,
        BottomRight = 9
    }
}
