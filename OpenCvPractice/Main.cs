using OpenCvPractice.Contours;
using OpenCvPractice.MotionDetection;
using OpenCvSharp;

using(OpenCvPractice.Camera.CameraCapture cam = new(3)) {
    while(true) {
        Contours contours = new Contours();
        MotionDetector detector = new(cam);
        Cv2.ImShow("Monitor", detector.Detection(true));

        Console.Clear();
        Console.WriteLine($"Frame Size: [{cam.width}] x [{cam.height}]");
        Console.WriteLine($"Border:\nP1({detector.min_x}, {detector.min_y})\nP2({detector.max_x}, {detector.max_y})");
        Console.WriteLine($"Border Size: {detector.max_x - detector.min_x} * {detector.max_y - detector.min_y}");

        cam.WaitKey(1);
    }
}