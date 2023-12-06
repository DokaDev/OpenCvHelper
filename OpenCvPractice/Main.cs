using OpenCvPractice.Contours;
using OpenCvPractice.MotionDetection;
using OpenCvSharp;

FaceDetection();

void MotionDetection() {
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
}

void FaceDetection() {
    CascadeClassifier faceCascade = new("haarcascade_frontalface_default.xml");
    CascadeClassifier smileCascade = new("haarcascade_smile.xml");

    using(OpenCvPractice.Camera.CameraCapture cam = new(3)) {
        while(true) {
            Mat frame = cam.GetFrame();
            Cv2.Flip(frame, frame, FlipMode.Y);
            Mat gray = frame.CvtColor(ColorConversionCodes.BGR2GRAY);

            var faces = faceCascade.DetectMultiScale(gray, scaleFactor: 1.1, minNeighbors: 12, minSize: new Size(20, 20));

            foreach(var b in faces) {
                Cv2.Rectangle(frame, new Point(b.X, b.Y), new Point(b.X + b.Width, b.Y + b.Height), Scalar.Red, 2);

                var smileface = smileCascade.DetectMultiScale(gray, scaleFactor: 3.5, minNeighbors: 15, minSize: new Size(10, 10));
                if(smileface.Length != 0) {
                    foreach(var s in smileface) {
                        Cv2.Rectangle(frame, new Point(s.X, s.Y), new Point(s.X + s.Width, s.Y + s.Height), Scalar.Yellow, 2, LineTypes.AntiAlias);
                    }
                }
            }
            Cv2.ImShow("frame", frame);

            cam.WaitKey(1);
        }
    }
}