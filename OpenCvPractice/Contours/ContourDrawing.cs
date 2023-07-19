using OpenCvSharp;

namespace OpenCvPractice.Contours {
    public partial class Contours {
        public enum Shape {
            Rectangle = 0,
            Contour = 1
        }

        public void DrawContours(Mat dst, Shape shape, Scalar scalar, int thickness) {
            if(contours.Length == 0)
                return;

            switch(shape) {
                case Shape.Rectangle:
                    foreach(var p in contours) {
                        Rect boundingRect = Cv2.BoundingRect(p);
                        Cv2.Rectangle(dst, boundingRect, scalar, thickness);
                    }
                    break;
                case Shape.Contour:
                    Cv2.DrawContours(dst, contours, -1, scalar, thickness, LineTypes.AntiAlias);
                    break;
            }
        }
    }
}
