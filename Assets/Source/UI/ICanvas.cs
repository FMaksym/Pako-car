public interface ICanvas 
{
   public virtual ICanvas Canvas { get => Canvas; set => Canvas = value; }

    public virtual void SetCanvas(ICanvas canvas)
    {
        Canvas = canvas;
    }
}
