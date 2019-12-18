namespace FinalEngine.Rendering.Direct3D11
{
    public sealed class Direct3D11Rasterizer : IRasterizer
    {
        public Direct3D11Rasterizer()
        {
            SetRasterState(RasterStateDescription.Default);
        }

        public void SetRasterState(RasterStateDescription description)
        {
            throw new System.NotImplementedException();
        }

        public void SetViewport(int x, int y, int width, int height)
        {
            throw new System.NotImplementedException();
        }
    }
}