using OpenCvSharp;

namespace OpenCvPractice.Contours {
    public partial class Contours {
        public Point[][] contours;
        public HierarchyIndex[] hierarchy;

        public int NumberOfContours {
            get {
                return contours.Length;
            }
        }
    }
}
