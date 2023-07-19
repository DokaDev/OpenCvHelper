using OpenCvSharp;
namespace OpenCvPractice.Camera {
    public partial class CameraCapture : IDisposable {
        public CameraCapture(int camNo) {
            this.camNo = camNo;
            vc = new(camNo);
        }
        public CameraCapture(string camDir) {
            this.camDir = camDir;
            vc = new(camDir);
        }
        
        public void Dispose() {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool flag) {
            if(!isDisposed) {
                if(flag) {
                    // TODO: Management Resource Cleanup
                }
                // Non-Management Resource Cleanup
                vc.Release();
                vc.Dispose();

                isDisposed = true;
            }
        }
        ~CameraCapture() {
            Dispose(false);
        }
    }
}
