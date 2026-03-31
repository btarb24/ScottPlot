namespace ScottPlot.Markers;

internal class EksWithLineLeft : IMarker
{
    public void Render(SKCanvas canvas, Paint paint, Pixel center, float size, MarkerStyle markerStyle)
    {
        float radius = size / 2;

        //Horizontal line
        SKPath path = new();
        path.MoveTo(center.X + radius, center.Y);
        path.LineTo(center.X - radius, center.Y);
        Drawing.DrawPath(canvas, paint, path, markerStyle.LineStyle);

        //Eks
        var eksCenter = center.MovedLeft(radius);
        var eksRadius= size / 4;
        var outlineThickness = markerStyle.OutlineStyle.Width;
        if (outlineThickness > 0)
        {
            SKPath EksOutlinePath = new();
            EksOutlinePath.MoveTo(eksCenter.X + eksRadius + outlineThickness, eksCenter.Y + eksRadius + outlineThickness);
            EksOutlinePath.LineTo(eksCenter.X - eksRadius - outlineThickness, eksCenter.Y - eksRadius - outlineThickness);
            EksOutlinePath.MoveTo(eksCenter.X - eksRadius - outlineThickness, eksCenter.Y + eksRadius + outlineThickness);
            EksOutlinePath.LineTo(eksCenter.X + eksRadius + outlineThickness, eksCenter.Y - eksRadius - outlineThickness);

            var xOutlineMarkerStyle = markerStyle.OutlineStyle.Clone();
            xOutlineMarkerStyle.Width = markerStyle.LineStyle.Width + (markerStyle.OutlineStyle.Width * 2);
            Drawing.DrawPath(canvas, paint, EksOutlinePath, xOutlineMarkerStyle);
        }

        SKPath EksFillPath = new();
        EksFillPath.MoveTo(eksCenter.X + eksRadius, eksCenter.Y + eksRadius);
        EksFillPath.LineTo(eksCenter.X - eksRadius, eksCenter.Y - eksRadius);
        EksFillPath.MoveTo(eksCenter.X - eksRadius, eksCenter.Y + eksRadius);
        EksFillPath.LineTo(eksCenter.X + eksRadius, eksCenter.Y - eksRadius);

        var xFillMarkerStyle = markerStyle.LineStyle.Clone();
        xFillMarkerStyle.Color = markerStyle.FillColor;
        Drawing.DrawPath(canvas, paint, EksFillPath, xFillMarkerStyle);
    }
}
